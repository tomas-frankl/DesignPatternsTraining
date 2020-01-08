using Calc.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Calc.Views
{
    class WpfViewHandler : IViewHandler
    {
        public void Hide(IView view)
        {
            ((Window)view).Hide();
        }

        public bool IsReady(IView view)
        {
            return view != null && ((Window)view).IsVisible;
        }

        public void Show(IView view)
        {
            ((Window)view).Show();
        }
    }
}
