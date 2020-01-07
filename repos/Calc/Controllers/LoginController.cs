using Calc.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Calc.Controllers
{
    class LoginController : ILoginController
    {
        IModelFacade model;
        ILoginView loginView { get; set; }
        ICalcView mainView { get; set; }
        IErrorView errorView { get; set; }

        IKernel container;

        public LoginController(IKernel container, IModelFacade model, IErrorView errorView)
        {
            this.container = container;
            this.model = model;
            //this.model = container.Get<IModelFacade>();
            this.errorView = errorView;
        }

        public void LoginAction(string userName, string password)
        {
            if(model.Login(userName, password))
            {
                //hide login
                loginView = container.Get<ILoginView>();
                ((Window)loginView).Hide();
                if (mainView==null)
                {
                    mainView = container.Get<ICalcView>();
                    ((Window)mainView).Show();
                }
            }
            else
            {
                //show error
                errorView.DisplayError("Wrong credentials");
            }
        }
    }
}
