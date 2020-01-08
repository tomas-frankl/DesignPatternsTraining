using Calc.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Calc.Views
{
    public class ErrorView : IView
    {
        ICalcController calcController;

        public ErrorView(ICalcController calcController)
        {
            this.calcController = calcController;
        }

        public void UpdateView()
        {
            System.Windows.MessageBox.Show(calcController.ErrorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
