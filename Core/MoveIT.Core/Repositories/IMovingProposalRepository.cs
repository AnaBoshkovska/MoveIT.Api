using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using MoveIT.Core.Models;

namespace MoveIT.Core.Repositories
{
    public interface IMovingProposalRepository : IRepository<MovingProposal, Guid>
    {
        Task<IEnumerable<MovingProposal>> GetAllAsync(Guid userId);

        Task<MovingProposal> GetByIdAsync(Guid id, Guid userId);
    }
}
