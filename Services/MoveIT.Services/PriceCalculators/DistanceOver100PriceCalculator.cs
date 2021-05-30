namespace MoveIT.Services.PriceCalculators
{
    public class DistanceOver100PriceCalculator : BaseDistancePriceCalculator
    {
        private const int basePrice = 10000;
        private const int additionPerKm = 7;

        public DistanceOver100PriceCalculator() : base(basePrice, additionPerKm)
        {

        }
    }
}
