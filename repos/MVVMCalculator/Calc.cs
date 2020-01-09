using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMCalculator
{
    public class Calc : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private double result;

        public double Result
        {
            get { return result; }
            set
            {
                result = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Result"));
            }
        }

        public void Plus(double x) => Result += x;
    }
}
