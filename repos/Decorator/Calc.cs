namespace Decorator
{
    partial class Program
    {
        public class Calc : ICalc
        {
            public double Result { get; set; }

            public void Plus(double x)
            {
                Result += x;
            }

        }
    }
}
