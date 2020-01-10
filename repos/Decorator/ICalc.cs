namespace Decorator
{
    public interface ICalc
    {
        double Result { get; set; }

        void Plus(double x);
    }
}