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

namespace kamafi.liability.services
{
    public class LiabilityRepository : ILiabilityRepository
    {
        private readonly ILogger<LiabilityRepository> _logger;
        private readonly IMapper _mapper;
        private readonly LiabilityContext _context;

        public LiabilityRepository(
            ILogger<LiabilityRepository> logger,
            IMapper mapper,        
            LiabilityContext context)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
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

        public IQueryable<Liability> GetQuery(bool asNoTracking = true)
        {
            var query = _context.Liabilities
                .Include(x => x.Type)
                .AsQueryable();

            return asNoTracking
                ? query.AsNoTracking()
                : query;
        }

        public async Task<object> AddAsync(
            object dto,
            string type)
        {
            if (type == "base")
            {
                return await AddAsync<Liability, LiabilityDto>(
                    Utils.DeserializeObject<LiabilityDto>(dto));
            }
            else if (type == "vehicle")
            {
                return await AddAsync<LiabilityVehicle, LiabilityVehicleDto>(
                    Utils.DeserializeObject<LiabilityVehicleDto>(dto));
            }
            else
            {
                throw new Exception("Error");
            }
        }

        private async Task<T> AddAsync<T, TDto>(TDto dto)
            where T : Liability
            where TDto : LiabilityDto
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