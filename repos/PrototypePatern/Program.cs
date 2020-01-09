using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePatern
{
    class Program
    {
        class XVnitrni : ICloneable
        {
            public string s;

            public XVnitrni()
            {
                s = "dloooouhaaaa inicializace";
            }

            public object Clone()
            {
                return MemberwiseClone();
            }

            public XVnitrni DeepClone()
            {
                return new XVnitrni() { s = this.s };
            }
        }

        class YVnejsi : ICloneable
        {
            public XVnitrni vnitrni = new XVnitrni();

            public YVnejsi()
            {
            }

            public object Clone()
            {
                //MemberwiseClone udela jenom shallow copy
                var y = (YVnejsi)MemberwiseClone();
                //proto musim potom naklonovat vsechny vnitrvni objekty
                y.vnitrni = (XVnitrni)vnitrni.Clone();
                return y;
            }

            public YVnejsi DeepClone()
            {
                return new YVnejsi() { vnitrni = this.vnitrni.DeepClone() };
            }
        }

        static void Main(string[] args)
        {
            var a = new XVnitrni();
            var b = (XVnitrni)a.Clone();

            var a2 = new YVnejsi();
            var b2 = (YVnejsi)a2.Clone();

            a2.vnitrni.s = "aaa";

            Console.WriteLine(a2.vnitrni.s);
            Console.WriteLine(b2.vnitrni.s);

            //IClonable
            //MemberWiseClose je protected a dela shallow copy

        }
    }
}
