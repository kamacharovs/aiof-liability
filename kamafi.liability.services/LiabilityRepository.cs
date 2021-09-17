using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Text.Json;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using AutoMapper;

using kamafi.liability.data;

/*
TODO
- Implement "Strategry" design pattern for all Liabilities
    https://refactoring.guru/design-patterns/strategy
Generic Repository Pattern
*/

namespace kamafi.liability.services
{
    public class LiabilityRepository<T, TDto> : ILiabilityRepository<T, TDto>
        where T : Liability
        where TDto : LiabilityDto
    {
        private readonly ILogger<LiabilityRepository<T, TDto>> _logger;
        private readonly IMapper _mapper;
        private readonly LiabilityContext _context;

        public LiabilityRepository(
            ILogger<LiabilityRepository<T, TDto>> logger,
            IMapper mapper,        
            LiabilityContext context)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        private IQueryable<LiabilityType> GetTypesQuery(bool asNoTracking = true)
        {
            var query = _context.LiabilityTypes
                .AsQueryable();

            return asNoTracking
                ? query.AsNoTracking()
                : query;
        }

        private IQueryable<T> GetQuery(bool asNoTracking = true)
        {
            var query = _context.Set<T>()
                .Include(x => x.Type)
                .AsQueryable();

            return asNoTracking
                ? query.AsNoTracking()
                : query;
        }

        private async Task<T> AddAsync(TDto dto)
        {
            var liability = _mapper.Map<T>(dto);

            liability.UserId = _context.Tenant.UserId;

            await _context.Set<T>().AddAsync(liability);
            await _context.SaveChangesAsync();

            _logger.LogInformation("{Tenant} | Created Liability with Id={LiabilityId}, PublicKey={LiabilityPublicKey} and UserId={LiabilityUserId}",
                _context.Tenant.Log,
                liability.Id,
                liability.PublicKey,
                liability.UserId);

            return liability;
        }
    }
}
