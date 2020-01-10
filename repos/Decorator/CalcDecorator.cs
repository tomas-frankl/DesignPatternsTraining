namespace Decorator
{
    abstract class CalcDecorator : ICalc
    {
        private ICalc calc;

        public double Result { get => calc.Result; set => calc.Result = value; }

        public CalcDecorator(ICalc calc)
        {
            this.calc = calc;
        }

        public void Plus(double x)
        {
            PrePlus(x);
            calc.Plus(x);
            PostPlus(x);
        }

        protected virtual void PrePlus(double x) { }
        protected virtual void PostPlus(double x) { }
    }
}
