using System;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

using AutoMapper;

using kamafi.liability.data;

namespace kamafi.liability.services
{
    public class VehicleRepository : 
        BaseRepository<Vehicle, VehicleDto>,
        IVehicleRepository
    {
        public VehicleRepository(
            ILogger<VehicleRepository> logger,
            IMapper mapper,        
            LiabilityContext context)
            : base(logger, mapper, context)
        { }

        public new async Task<Vehicle> AddAsync(VehicleDto dto)
        {
            return await base.AddAsync(dto);
        }
    }
}