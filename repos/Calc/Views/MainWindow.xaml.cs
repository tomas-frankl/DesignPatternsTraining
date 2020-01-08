using Calc.Controllers;
using Calc.Models;
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
    public partial class MainWindow : Window, IView
    {
        ICalcController calcController;
        IModelFacade model;

        public MainWindow(ICalcController calcController, IModelFacade model)
        {
            this.calcController = calcController;
            this.model = model;
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

        private void showLogButton_Click(object sender, RoutedEventArgs e)
        {
            calcController.ShowLogWindowAction();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            calcController.ExitApplication();
        }

        public void UpdateView()
        {
            resultLabel.Content = model.Result; 
        }
    }
}
