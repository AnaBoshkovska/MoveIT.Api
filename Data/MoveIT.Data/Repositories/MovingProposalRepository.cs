using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

using MoveIT.Core.Models;
using MoveIT.Core.Repositories;

namespace MoveIT.Data.Repositories
{
    public class MovingProposalRepository : BaseRepository<MovingProposal, Guid>, IMovingProposalRepository
    {
        private MoveItDbContext MoveItDbContext => Context as MoveItDbContext;

        public MovingProposalRepository(MoveItDbContext context) : base(context)
        {
            
        }

        public override async Task<IEnumerable<MovingProposal>> GetAllAsync()
        {
            return await MoveItDbContext.MovingProposals.AsNoTracking().Include(x => x.User)
                .ToListAsync();
        }

        public async Task<IEnumerable<MovingProposal>> GetAllAsync(Guid id)
        {
            return await MoveItDbContext.MovingProposals.AsNoTracking().Include(x => x.User)
                .Where(x => x.UserId == id)
                .ToListAsync();
        }

        public override async Task<MovingProposal> GetByIdAsync(Guid id)
        {
            return await MoveItDbContext.MovingProposals.AsNoTracking().Include(x => x.User)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<MovingProposal> GetByIdAsync(Guid id, Guid userId)
        {
            return await MoveItDbContext.MovingProposals.AsNoTracking().Include(x => x.User)
                .Where(x => x.UserId == userId)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public override void Update(MovingProposal movingProposal)
        {
            Context.Set<MovingProposal>().Attach(movingProposal);
            Context.Entry(movingProposal).State = EntityState.Modified;
            Context.Entry(movingProposal).Property(nameof(MovingProposal.UserId)).IsModified = false;
            Context.Entry(movingProposal).Property(nameof(MovingProposal.CreateDate)).IsModified = false;
        }
    }
}
