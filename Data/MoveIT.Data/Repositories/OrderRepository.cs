using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using MoveIT.Core.Models;
using MoveIT.Core.Repositories;

namespace MoveIT.Data.Repositories
{
    public class OrderRepository : BaseRepository<Order, Guid>, IOrderRepository
    {
        private MoveItDbContext MoveItDbContext => Context as MoveItDbContext;

        public OrderRepository(MoveItDbContext context) : base(context)
        {

        }

        public override async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await MoveItDbContext.Orders.Include(x => x.MovingProposal)
                .ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetAllAsync(Guid userId)
        {
            return await MoveItDbContext.Orders.Include(x => x.MovingProposal)
                .Where(x => x.MovingProposal != null && x.MovingProposal.UserId == userId)
                .ToListAsync();
        }

        public override async Task<Order> GetByIdAsync(Guid id)
        {
            return await MoveItDbContext.Orders.Include(x => x.MovingProposal)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Order> GetByIdAsync(Guid id, Guid userId)
        {
            return await MoveItDbContext.Orders.Include(x => x.MovingProposal)
                .Where(x => x.MovingProposal != null && x.MovingProposal.UserId == userId)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Order> GetByMovingProposalId(Guid movingProposalId)
        {
            return await MoveItDbContext.Orders.Include(x => x.MovingProposal)
                .FirstOrDefaultAsync(x => x.MovingProposal.Id == movingProposalId);
        }
    }
}
