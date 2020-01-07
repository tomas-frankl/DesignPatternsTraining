using Calc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc.Controllers
{
    public class CalcController : ICalcController
    {
        IModelFacade calcModel;
        public ICalcView CalcView { get; set; }

        private void calculate(Action<double> operation, string x)
        {
            var dx = double.Parse(x);
            operation(dx);
            CalcView.UpdateView(calcModel.Result.ToString());
        }

        public CalcController(IModelFacade calcModel)
        {
            this.calcModel = calcModel;
        }

        public void PlusAction(string x) => calculate(calcModel.Plus, x);
        public void MinusAction(string x) => calculate(calcModel.Minus, x); 
    }
}
