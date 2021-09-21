using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using kamafi.liability.data;

namespace kamafi.liability.services.handlers
{
    public class LiabilityHandler : AbstractLiabilityHandler
    {
        private readonly ILiabilityRepository _repo;
        // TODO add fluent validator logic here

        public LiabilityHandler(
            ILiabilityRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        protected override bool CanHandleAdd(LiabilityDto dto)
        {
            // TODO add JsonSerialization logic
            return true;
        }

        protected override bool CanHandleUpdate(LiabilityDto dto)
        {
            throw new NotImplementedException();
        }

        protected override async Task<Liability> OnAddAsync(LiabilityDto dto)
        {
            return await _repo.AddAsync<Liability, LiabilityDto>(dto);
        }

        protected override Task<Liability> OnUpdateAsync(LiabilityDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
