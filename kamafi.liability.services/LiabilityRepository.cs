using System;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

using AutoMapper;

using kamafi.liability.data;

namespace kamafi.liability.services
{
    public class LiabilityRepository : 
        BaseRepository<Liability, LiabilityDto>, 
        ILiabilityRepository
    {
        public LiabilityRepository(
            ILogger<LiabilityRepository> logger,
            IMapper mapper,        
            LiabilityContext context)
            : base(logger, mapper, context)
        { }

        public new async Task<Liability> AddAsync(LiabilityDto dto)
        {
            return await base.AddAsync(dto);
        }
    }
}