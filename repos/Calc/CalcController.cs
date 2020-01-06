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
        public MainWindow MainView { get; set; }

        public CalcController(ICalcModel calcModel)
        {
            this.calcModel = calcModel;
        }

        public void PlusAction(string x)
        {
            var dx = double.Parse(x);
            
            calcModel.Plus(dx);

            MainView.UpdateView(calcModel.Result.ToString());
        }
    }
}
