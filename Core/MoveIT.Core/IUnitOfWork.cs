using System;
using System.Threading.Tasks;

using MoveIT.Core.Repositories;

namespace MoveIT.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IMovingProposalRepository MovingProposals { get; }

        IOrderRepository MovingOrders { get; }

        Task<int> CommitAsync();
    }
}
