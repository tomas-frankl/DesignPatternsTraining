namespace Calc.Controllers
{
    public interface ICalcController
    {
        void PlusAction(string x);
        void MinusAction(string x);

        void ShowLogWindowAction();
        void ExitApplication();
    }
}