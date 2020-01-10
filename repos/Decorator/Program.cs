using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{

    partial class Program
    {
        static void Main(string[] args)
        {
            var calc = new Calc();
            var logCalcDec = new LoggingCalcDecorator(calc);
            var roundCalcDec = new RoundingCalcDecorator(logCalcDec);

            roundCalcDec.Plus(10.33333);

            Console.WriteLine(logCalcDec.Result);
        }
    }
}
