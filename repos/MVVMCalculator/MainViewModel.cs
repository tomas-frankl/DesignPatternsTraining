using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMCalculator
{
    public class MainViewModel : INotifyPropertyChanged
    {
        Calc model;

        public MainViewModel(Calc model)
        {
            this.model = model;
            model.PropertyChanged += Model_PropertyChanged;
            PlusCommand = new PlusCommand(model);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private double result;

        private void Model_PropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == "Result")
                Result = model.Result;
        }

        public double Result {
            get { return result; }
            set {
                result = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Result"));
            }
        }

        public PlusCommand PlusCommand { get; private set; }
    }
}
