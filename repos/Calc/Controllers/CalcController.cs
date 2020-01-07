using Calc.Models;
using Calc.Views;
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
        IModelFacade calcModel;
        public ICalcView CalcView { get; set; }
        public ILogView LogView { get; set; }
        public IErrorView ErrorView { get; set; }

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

            CalcView.UpdateView(calcModel.Result.ToString());
            LogView?.UpdateView(calcModel.LogItems);
            //2.
            //stejne tak zde funguje controller jako mediator, protoze zprostredkovama update log window
        }

        public CalcController(IModelFacade calcModel, IErrorView errorView)
        {
            this.calcModel = calcModel;
            this.ErrorView = errorView;
        }

        public void PlusAction(string x) => calculate(calcModel.Plus, x);
        public void MinusAction(string x) => calculate(calcModel.Minus, x);

        public void ShowLogWindowAction()
        {
            if (LogView == null || !((Window)LogView).IsVisible)
            {
                LogView = new LogWindow();
                ((Window)LogView).Show();
            }

            LogView.UpdateView(calcModel.LogItems);
            //1.
            //kdyz by bylo vice ruznych oken, volajicich tuto akci pro zobrazeni logu, tak Controller bude zaroven fungovat jako Mediator
            //muze to byt implementovano jako samostatna trida        }
        }

        public void ShowErrorWindowAction(string errorMessage)
        {
            ErrorView.DisplayError(errorMessage);
        }

        public void ExitApplication()
        {
            App.Current.Shutdown();
        }
    }
}
