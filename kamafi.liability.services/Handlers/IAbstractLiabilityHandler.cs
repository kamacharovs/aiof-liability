using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using kamafi.liability.data;

namespace kamafi.liability.services.handlers
{
    public interface IAbstractLiabilityHandler
    {
        Task<Liability> HandleAddAsync(object dto);
        Task<Liability> HandleUpdateAsync(object dto);
    }
}
