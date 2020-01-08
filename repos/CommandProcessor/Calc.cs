using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandProcessor
{
    public class Calc
    {
        public double Result { get; private set; }
        public void Plus(double x) => Result += x;
        public int PlusMS()
        {
            int ms = DateTime.Now.Millisecond;
            Result += ms;
            return ms;
        }
    }
}
