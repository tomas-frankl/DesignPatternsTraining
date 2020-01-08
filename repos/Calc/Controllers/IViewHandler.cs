namespace Calc.Controllers
{
    internal interface IViewHandler
    {
        void Hide(IView view);
        void Show(IView view);
        bool IsReady(IView view);
    }
}