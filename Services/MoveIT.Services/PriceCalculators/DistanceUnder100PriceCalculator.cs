namespace MoveIT.Services.PriceCalculators
{
    public class DistanceUnder100PriceCalculator : BaseDistancePriceCalculator
    {
        private const int basePrice = 5000;
        private const int additionPerKm = 8;

        public DistanceUnder100PriceCalculator() : base(basePrice, additionPerKm)
        {

        }
    }
}
