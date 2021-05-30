using MoveIT.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoveIT.Services.PriceCalculators
{
    public class BaseDistancePriceCalculator : IDistancePriceCalculator
    {
        private int _basePrice;
        private int _additionPerKm;


        public BaseDistancePriceCalculator(int basePrice, int additionPerKm)
        {
            _basePrice = basePrice;
            _additionPerKm = additionPerKm;
        }

        public virtual int CalculatePrice(int distance)
        {
            return _basePrice + (distance * _additionPerKm);
        }
    }
}
