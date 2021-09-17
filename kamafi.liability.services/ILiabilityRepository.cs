using System;

using kamafi.liability.data;

namespace kamafi.liability.services
{
    public interface ILiabilityRepository<T, TDto>
        where T : Liability
        where TDto : LiabilityDto
    {
        
    }
}