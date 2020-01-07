namespace Calc.Controllers
{
    public interface ICalcController
    {
        void PlusAction(string x);
        void MinusAction(string x);

        ICalcView CalcView { get; set; }
    }
}