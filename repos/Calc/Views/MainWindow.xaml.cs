using Calc.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calc.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, ICalcView
    {
        ICalcController calcController;
 
        public MainWindow(ICalcController calcController)
        {
            this.calcController = calcController;
            calcController.CalcView = this;

            InitializeComponent();
        }

        private void plusButton_Click(object sender, RoutedEventArgs e)
        {
            calcController.PlusAction(inputTextBox.Text);
        }

        private void minusButton_Click(object sender, RoutedEventArgs e)
        {
            calcController.MinusAction(inputTextBox.Text);
        }

        public void UpdateView(string result)
        {
            resultLabel.Content = result;
        }
    }
}
