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
using System.Windows.Shapes;

namespace Calc.Views
{
    /// <summary>
    /// Interaction logic for LogWindow.xaml
    /// </summary>
    public partial class LogWindow : Window, ILogView
    {

        public LogWindow()
        {
            InitializeComponent();
        }

        public void UpdateView(IEnumerable<string> logItems)
        {
            itemsListBox.Items.Clear();
            foreach (var item in logItems)
                itemsListBox.Items.Add(item);
        }
    }
}
