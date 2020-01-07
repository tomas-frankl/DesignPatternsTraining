using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Calc.Models;
using Calc.Controllers;
using Calc.Views;
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
            
            //models
            container.Bind<ICalcModel>().To<CalcModel>();
            container.Bind<ILogger>().To<Logger>().InSingletonScope();
            container.Bind<IModelFacade>().To<ModelFacade>().InSingletonScope();
            container.Bind<IErrorView>().To<ErrorView>().InSingletonScope();

            //controllers
            container.Bind<ICalcController>().To<CalcController>();
            
            //view
            MainWindow = container.Get<MainWindow>();
            MainWindow.Show();
        }
    }
}
