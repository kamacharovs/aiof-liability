﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Text.Json;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using AutoMapper;
using FluentValidation;

using kamafi.liability.data;

namespace kamafi.liability.services
{
    public abstract class BaseRepository<T, TDto>
        where T : Liability
        where TDto : LiabilityDto
    {
        private readonly ILogger<BaseRepository<T, TDto>> _logger;
        private readonly IValidator<TDto> _validator;
        private readonly IMapper _mapper;
        private readonly LiabilityContext _context;

        public BaseRepository(
            ILogger<BaseRepository<T, TDto>> logger,
            IValidator<TDto> validator,
            IMapper mapper,
            LiabilityContext context)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IQueryable<LiabilityType> GetTypesQuery(bool asNoTracking = true)
        {
            var query = _context.LiabilityTypes
                .AsQueryable();

            return asNoTracking
                ? query.AsNoTracking()
                : query;
        }

        public IQueryable<T> GetQuery(bool asNoTracking = true)
        {
            var query = _context.Set<T>()
                .Include(x => x.Type)
                .AsQueryable();

            return asNoTracking
                ? query.AsNoTracking()
                : query;
        }

        public async Task<T> AddAsync(TDto dto)
        {
            var validatorResult = await _validator.ValidateAsync(dto, o => o.IncludeRuleSets(Constants.AddRuleSetMap[typeof(TDto).Name]));

            if (!validatorResult.IsValid) throw new ValidationException(validatorResult.Errors);

            var liability = _mapper.Map<T>(dto);

            liability.UserId = (int)_context.Tenant.UserId;

            await _context.Set<T>().AddAsync(liability);
            await _context.SaveChangesAsync();

            _logger.LogInformation("{Tenant} | Created Liability with Id={LiabilityId}, PublicKey={LiabilityPublicKey} and UserId={LiabilityUserId}",
                _context.Tenant.Log,
                liability.Id,
                liability.PublicKey,
                liability.UserId);

            return liability;
        }

        public async Task DeleteAsync(int id)
        {
            var asset = await _context.Set<T>()
                .FirstOrDefaultAsync(x => x.Id == id)
                ?? throw new core.data.KamafiNotFoundException($"Liability with Id={id} was not found");

            asset.IsDeleted = true;

            _context.Set<T>().Update(asset);
            await _context.SaveChangesAsync();

            _logger.LogInformation("{Tenant} | Soft Deleted Liability with Id={LiabilityId}",
                _context.Tenant.Log,
                id);
        }
    }
}
