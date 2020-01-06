using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    //SimpleFactory je totez jako AbstractFactory, ale vytvari jen jeden typ objektu, a ne sadu objektu, tj. napriklad jenom ISquare
    interface IShapeFactory
    {
        ISquare CreateSquare();
        ICircle CreateCircle();
    }
}
