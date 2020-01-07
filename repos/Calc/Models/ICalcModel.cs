namespace Calc.Models
{
    public interface ICalcModel
    {
        double Result { get; }

        void Plus(double x);
        void Minus(double x);
    }
}