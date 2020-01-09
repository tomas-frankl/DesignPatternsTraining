using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    class Order
    {
        public string Customer { get; set; }
        public double Price { get; set; }
        public string Text { get; set; }
    }
}
