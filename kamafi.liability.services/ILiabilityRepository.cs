using System;
using System.Threading.Tasks;

using kamafi.liability.data;

namespace kamafi.liability.services
{
    public interface ILiabilityRepository
    {
        Task<T> AddAsync<T, TDto>(TDto dto)
            where T : Liability
            where TDto : LiabilityDto;
    }
}