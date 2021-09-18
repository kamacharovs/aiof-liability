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
    public class LiabilityRepository : BaseRepository<Liability, LiabilityDto>,
        ILiabilityRepository
    {
        private readonly ILogger<LiabilityRepository> _logger;
        private readonly IMapper _mapper;
        private readonly LiabilityContext _context;

        public LiabilityRepository(
            ILogger<LiabilityRepository> logger,
            IMapper mapper,        
            LiabilityContext context)
            : base(logger, mapper, context)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public new async Task<Liability> AddAsync(LiabilityDto dto)
        {
            return await base.AddAsync(dto);
        }
    }
}