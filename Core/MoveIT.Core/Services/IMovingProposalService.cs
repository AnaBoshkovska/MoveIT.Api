using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using MoveIT.Core.Models;

namespace MoveIT.Core.Services
{
    public interface IMovingProposalService
    {
        Task<IEnumerable<MovingProposalPrice>> GetAll(Guid userId);

        Task<MovingProposalPrice> Get(Guid id, Guid userId);

        Task<MovingProposalPrice> Create(MovingProposal movingProposal);

        Task Update(MovingProposal movingProposal);

        Task Delete(MovingProposal movingProposal);       
    }
}
