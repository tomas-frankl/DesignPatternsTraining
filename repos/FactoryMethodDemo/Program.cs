﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var CA = new ClassA();
            CA.UseB();

            var CA1 = new BetterClassA();
            CA1.UseB();

        }
    }
}
