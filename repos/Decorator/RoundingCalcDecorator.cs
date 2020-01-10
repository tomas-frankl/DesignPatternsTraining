using System;

namespace Decorator
{
    class RoundingCalcDecorator : CalcDecorator
    {
        public RoundingCalcDecorator(ICalc calc) : base(calc)
        {
        }

        protected override void PostPlus(double x)
        {
            Result = Math.Round(Result);
        }
    }
}
