using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVVMCalculator
{
    public partial class MVVMCalculator : Form
    {
        MainViewModel model;

        public MVVMCalculator(MainViewModel model)
        {
            InitializeComponent();
            this.model = model;
            this.model.PropertyChanged += ViewModel_PropertyChanged;
        }

        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == "Result")
                label1.Text = model.Result.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(textBox1.Text, out double x))
            {
                model.PlusCommand.X = x;
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            model.PlusCommand.Execute();
        }
    }
}
