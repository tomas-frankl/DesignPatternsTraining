using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc
{
    public class CalcController : ICalcController
    {
        ICalcModel calcModel;
        public ICalcView CalcView { get; set; }

        private void calculate(Action<double> operation, string x)
        {
            var dx = double.Parse(x);
            operation(dx);
            CalcView.UpdateView(calcModel.Result.ToString());
        }

        public CalcController(ICalcModel calcModel)
        {
            this.calcModel = calcModel;
        }

        public void PlusAction(string x) => calculate(calcModel.Plus, x);
        public void MinusAction(string x) => calculate(calcModel.Minus, x); 
    }
}
