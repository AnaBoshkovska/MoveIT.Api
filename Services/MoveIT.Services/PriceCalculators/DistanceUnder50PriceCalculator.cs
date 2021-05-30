namespace MoveIT.Services.PriceCalculators
{
    public class DistanceUnder50PriceCalculator : BaseDistancePriceCalculator
    {
        private const int basePrice = 1000;
        private const int additionPerKm = 10;

        public DistanceUnder50PriceCalculator() : base(basePrice, additionPerKm)
        {

        }

    }
}
