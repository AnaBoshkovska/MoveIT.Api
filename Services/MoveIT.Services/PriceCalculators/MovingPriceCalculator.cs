using MoveIT.Core.Models;
using MoveIT.Core.Services;

namespace MoveIT.Services.PriceCalculators
{
    public class MovingPriceCalculator : IMovingPriceCalculator
    {
        private const int pianoPrice = 5000;

        public int CalculatePrice(MovingProposal movingProposal)
        {
            var distancePriceCalculator = DistanceCalculatorFactory.CreateInstance(movingProposal.Distance);
            var distancePrice = distancePriceCalculator.CalculatePrice(movingProposal.Distance);
            var numberOfCars = CalculateNumberOfCars(movingProposal.LivingAreaSurface, movingProposal.AtticAreaSurface);

            return (distancePrice * numberOfCars) + CalculatePianoPrice(movingProposal.HasPiano);
        }

        private int CalculateNumberOfCars(int livingArea, int atticArea)
        {
            var area = livingArea + (atticArea * 2);
            return (area / 50) + 1;
        }

        private int CalculatePianoPrice(bool hasPiano)
        {
            if (hasPiano)
                return pianoPrice;
            return 0;
        }
    }
}
