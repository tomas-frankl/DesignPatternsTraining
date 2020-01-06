using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc
{
    public class CalcController : ICalcController
    {
        ICalculator calculator;
        public MainWindow MainView { get; set; }

        public CalcController(ICalculator calculator)
        {
            this.calculator = calculator;
        }

        public void PlusAction(string x)
        {
            var dx = double.Parse(x);
            
            calculator.Plus(dx);

            MainView.UpdateView(calculator.Result.ToString());
        }
    }
}
