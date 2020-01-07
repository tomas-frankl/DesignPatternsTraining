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

        private void calculate(Action<double> operation, string x)
        {
            var dx = double.Parse(x);
            operation(dx);
            CalcView.UpdateView(calcModel.Result.ToString());
            LogView?.UpdateView(calcModel.LogItems);
        }

        public CalcController(IModelFacade calcModel)
        {
            this.calcModel = calcModel;
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
        }
    }
}
