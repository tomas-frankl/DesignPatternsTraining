using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandDemo
{
    public interface ICommand
    {
        void Execute();
    }

    public interface ICommand<T> : ICommand
    {
        T Receiver { get; set; }
    }
}
