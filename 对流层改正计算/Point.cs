using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 对流层改正计算
{
   public class Point
    {
       public string Id;
       public double B;
       public double L;
       public double H;
        public DateTime time;
        public double El;

        public Point (string id , double b , double l , double h , double el)
        {
            this.Id = id;
            this.B = b;
            this.L = l;
            this.H = h;
            this.El = el;
        }

        public Point (string id , string b , string l , string h  , string el , DateTime dt)
        {
            this.time = dt;
            this.Id = id;
            this.B = Convert.ToDouble(b);
            this.L = Convert.ToDouble(l);
            this.H = Convert.ToDouble(h);
            this.El = Convert.ToDouble(el);

        }
    }
}
