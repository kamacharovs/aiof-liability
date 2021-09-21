using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using kamafi.liability.data;

namespace kamafi.liability.services.handlers
{
    /// <summary>
    /// Abstract liability handler. Uses <see href="https://refactoring.guru/design-patterns/chain-of-responsibility/csharp/example">Chain of Responsibility</see>
    /// pattern. You can chain behaviour by using the <see cref="AbstractLiabilityHandler.SetNext(IAbstractLiabilityHandler)"/> method.
    /// </summary>
    public abstract class AbstractLiabilityHandler : IAbstractLiabilityHandler
    {
        private IAbstractLiabilityHandler _nextHandler;

        public IAbstractLiabilityHandler SetNext(IAbstractLiabilityHandler nextHandler)
        {
            _nextHandler = nextHandler ?? throw new ArgumentNullException(nameof(nextHandler));

            return this;
        }

        async Task<Liability> IAbstractLiabilityHandler.HandleAddAsync(object dto)
        {
            if (dto is null) throw new ArgumentNullException(nameof(dto));

            if (CanHandleAdd(dto))
            {
                return await OnAddAsync(dto);
            }

            return await _nextHandler?.HandleAddAsync(dto) ?? throw new InvalidOperationException($"Next handler not set for type '{this.GetType().Name}' and operation 'Add'");
        }

        async Task<Liability> IAbstractLiabilityHandler.HandleUpdateAsync(object dto)
        {
            if (dto is null) throw new ArgumentNullException(nameof(dto));

            if (CanHandleUpdate(dto))
            {
                return await OnUpdateAsync(dto);
            }

            return await _nextHandler?.HandleUpdateAsync(dto) ?? throw new InvalidOperationException($"Next handler not set for type '{this.GetType().Name}' and operation 'Update'");
        }

        protected abstract Task<Liability> OnAddAsync(object dto);
        protected abstract Task<Liability> OnUpdateAsync(object dto);
        protected abstract bool CanHandleAdd(object dto);
        protected abstract bool CanHandleUpdate(object dto);
    }
}
