using MoveIT.Core.Models;

namespace MoveIT.Core.Services
{
    public interface IMovingPriceCalculator
    {
        public int CalculatePrice(MovingProposal movingProposal);
    }
}
