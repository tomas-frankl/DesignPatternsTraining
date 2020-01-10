using System;

namespace Decorator
{
    class LoggingCalcDecorator : CalcDecorator
    {
        double prevResult;
        
        public LoggingCalcDecorator(ICalc calc) : base(calc)
        {
        }

        protected override void PostPlus(double x)
        {
            Console.WriteLine($"Old result: {prevResult} New Result: {Result}");
        }

        protected override void PrePlus(double x)
        {
            prevResult = Result;
        }
    }
}
