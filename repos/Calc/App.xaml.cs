using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Ninject;

namespace Calc
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var container = new StandardKernel();
            container.Bind<ICalcModel>().To<CalcModel>();
            container.Bind<ICalcController>().To<CalcController>();
            container.Bind<ICalcView>().To<MainWindow>();

            
            
            var calcController = container.Get<ICalcController>();
            var mainView = new MainWindow(calcController);

            MainWindow = mainView;
            MainWindow.Show();
        }
    }
}
