using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using MoveIT.Core.Models;

namespace MoveIT.Core.Repositories
{
    public interface IOrderRepository: IRepository<Order, Guid>
    {
        Task<IEnumerable<Order>> GetAllAsync(Guid userId);

        Task<Order> GetByMovingProposalId(Guid movingProposalId);

        Task<Order> GetByIdAsync(Guid id, Guid userId);
    }
}
