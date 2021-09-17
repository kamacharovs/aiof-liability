using System;
using System.Threading.Tasks;

using kamafi.liability.data;

namespace kamafi.liability.services
{
    public class Context
    {
        public Context()
        {
            
        }
    }

    public class Strategy<T, TDto>
        where T : Liability
        where TDto : LiabilityDto
    {
    }

    public class BaseStrategy : Strategy<Liability, LiabilityDto>
    {

    }
}