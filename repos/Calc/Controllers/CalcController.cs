using Calc.Models;
using Calc.Views;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Calc.Controllers
{
    public class CalcController : ICalcController
    {
        IKernel container;
        public IModelFacade calcModel;
        IViewHandler viewHandler;
        IView LogView { get; set; }
        public string ErrorMessage { get; set; }

        private double getOperand(string x)
        {
            try
            {
                return double.Parse(x);
            }
            catch (FormatException ex)
            {
                throw new ArgumentException("Invalid argument.", ex);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Unexpected exception.", ex);
            }
        }

        private void calculate(Action<double> operation, string x)
        {
            try
            {
                var dx = getOperand(x);
                operation(dx);
            }
            catch (Exception ex)
            {
                ShowErrorWindowAction($"{ex.Message} {ex?.InnerException.Message}");
            }

            
            container.Get<IView>("Main").UpdateView();
            LogView?.UpdateView();
            //2.
            //stejne tak zde funguje controller jako mediator, protoze zprostredkovama update log window
        }

        public CalcController(IKernel container)
        {
            this.container = container;
            this.viewHandler = container.Get<IViewHandler>();
            this.calcModel = container.Get<IModelFacade>();
        }

        public void PlusAction(string x) => calculate(calcModel.Plus, x);
        public void MinusAction(string x) => calculate(calcModel.Minus, x);

        public void ShowLogWindowAction()
        {
            if (!viewHandler.IsReady(LogView))
            {
                viewHandler.Show(LogView);
            }

            LogView.UpdateView();
            //1.
            //kdyz by bylo vice ruznych oken, volajicich tuto akci pro zobrazeni logu, tak Controller bude zaroven fungovat jako Mediator
            //muze to byt implementovano jako samostatna trida        }
        }

        public void ShowErrorWindowAction(string errorMessage)
        {
            this.ErrorMessage = errorMessage;
            container.Get<IView>("Error").UpdateView();
        }

        public void ExitApplication()
        {
            App.Current.Shutdown();
        }
    }
}
