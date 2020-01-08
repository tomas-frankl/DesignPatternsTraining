namespace Calc.Controllers
{
    public interface ICalcController
    {
        string ErrorMessage { get; set; }

        void PlusAction(string x);
        void MinusAction(string x);

        void ShowLogWindowAction();
        void ExitApplication();
    }
}