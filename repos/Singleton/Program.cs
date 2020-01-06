using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SingletonDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Singleton.Instance.DoStuff();
            SingletonNew.Instance.DoStuff();

            //tohle nejsou ve skutecnosti singletony i kdyz vyuzivaji podobny princip:
            var appSettings = ConfigurationManager.AppSettings;
            var currentThread = Thread.CurrentThread;
        }
    }
}
