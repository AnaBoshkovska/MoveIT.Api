using MoveIT.Core.Services;

namespace MoveIT.Services.PriceCalculators
{
    public class DistanceCalculatorFactory
    {
        public static IDistancePriceCalculator CreateInstance(int distance)
        {
            IDistancePriceCalculator distancePriceCalculator = null;

            switch (distance)
            {
                case int x when (distance < 50):
                    distancePriceCalculator = new DistanceUnder50PriceCalculator();
                    break;
                case int x when (distance < 100):
                    distancePriceCalculator = new DistanceUnder100PriceCalculator();
                    break;
                case int x when (distance >= 100):
                    distancePriceCalculator = new DistanceOver100PriceCalculator();
                    break;
            }

            return distancePriceCalculator;
        }
    }
}
