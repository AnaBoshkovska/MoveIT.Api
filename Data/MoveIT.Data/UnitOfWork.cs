using System.Threading.Tasks;

using MoveIT.Core;
using MoveIT.Core.Repositories;
using MoveIT.Data.Repositories;

namespace MoveIT.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MoveItDbContext _context;
        private MovingProposalRepository _movingProposalRepository;
        private OrderRepository _movingOrderRepository;

        public IMovingProposalRepository MovingProposals => _movingProposalRepository = _movingProposalRepository ?? new MovingProposalRepository(_context);
        public IOrderRepository MovingOrders => _movingOrderRepository = _movingOrderRepository ?? new OrderRepository(_context);

        public UnitOfWork(MoveItDbContext context)
        {
            _context = context;
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
