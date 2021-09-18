using System;
using System.Threading.Tasks;

using kamafi.liability.data;

namespace kamafi.liability.services
{
    public interface ILiabilityRepository
    {
        Task<Liability> AddAsync(LiabilityDto dto);
    }
}