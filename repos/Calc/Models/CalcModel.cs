using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc.Models
{
    public class CalcModel : ICalcModel
    {
        public double Result { get; private set; }

        public void Plus(double x) => Result += x;
        public void Minus(double x) => Result -= x;
    }
}
