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

        public CalcController(ICalcModel calcModel)
        {
            this.calcModel = calcModel;
        }

        public void PlusAction(string x)
        {
            var dx = double.Parse(x);
            
            calcModel.Plus(dx);

            CalcView.UpdateView(calcModel.Result.ToString());
        }
        public void MinusAction(string x)
        {
            var dx = double.Parse(x);

            calcModel.Minus(dx);

            CalcView.UpdateView(calcModel.Result.ToString());
        }
    }
}
