using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using MoveIT.Core.Models;

namespace MoveIT.Core.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetAll(Guid userId);

        Task<Order> Get(Guid id, Guid userId);

        Task<Order> GetByMovingProposalId(Guid movingProposalId, Guid userId);

        Task<Order> Create(Order order);

        Task Delete(Order order);
    }
}
