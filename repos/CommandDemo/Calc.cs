﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandDemo
{
    public class Calc
    {
        public double Result { get; private set; }
        public void Plus(double x) => Result += x;

    }
}
