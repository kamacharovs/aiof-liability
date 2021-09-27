using System;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

using AutoMapper;
using FluentValidation;

using kamafi.liability.data;

namespace kamafi.liability.services
{
    public class LiabilityRepository : 
        BaseRepository<Liability, LiabilityDto>, 
        ILiabilityRepository
    {
        public LiabilityRepository(
            ILogger<LiabilityRepository> logger,
            IValidator<LiabilityDto> validator,
            IMapper mapper,
            LiabilityContext context)
            : base(logger, validator, mapper, context)
        { }

        public new async Task<Liability> AddAsync(LiabilityDto dto)
        {
            return await base.AddAsync(dto);
        }
    }
}