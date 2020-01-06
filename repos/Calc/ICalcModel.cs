namespace Calc
{
    public interface ICalcModel
    {
        double Result { get; }

        void Plus(double x);
    }
}