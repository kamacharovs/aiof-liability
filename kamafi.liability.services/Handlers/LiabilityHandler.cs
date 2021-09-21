using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

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

        protected override bool CanHandleAdd(object dto)
        {
            return Utils.CanDeserialize<LiabilityDto>(dto);
        }

        protected override bool CanHandleUpdate(object dto)
        {
            throw new NotImplementedException();
        }

        protected override async Task<Liability> OnAddAsync(object dto)
        {
            return await _repo.AddAsync<Liability, LiabilityDto>(Utils.DeserializeObject<LiabilityDto>(dto));
        }

        protected override Task<Liability> OnUpdateAsync(object dto)
        {
            throw new NotImplementedException();
        }
    }
}
