using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Math
{
    struct comp
    {
        private double a, b;
        public comp((double x, double y) value)
        {
            a = value.x;
            b = value.y;
        }
        public static implicit operator comp(double d)
        {
            return new comp((d, 0));
        }
        public static implicit operator comp((double, double) d)
        {
            return new comp((d.Item1, d.Item2));
        }
        public static implicit operator string(comp c)
        {
            return c.ToString();
        }

        //(+)
        public static comp operator +(comp c1, comp c2)
        {
            return (c1.a + c2.a, c1.b + c2.b);
        }

        //(-)
        public static comp operator -(comp c1, comp c2)
        {
            return (c1.a - c2.a, c1.b - c2.b);
        }



        //(+)
        public static comp operator +(comp c, double a)
        {
            return (c.a + a, c.b);
        }
        public static comp operator +(double a, comp c)
        {
            return (c.a + a, c.b);
        }


        //(-)
        public static comp operator -(comp c, double a)
        {
            return (c.a - a, c.b);
        }
        public static comp operator -(double a, comp c)
        {
            return (c.a - a, c.b);
        }


        //(*)
        public static comp operator *(comp a, comp b)
        {
            return (a.a*b.a -a.b*b.b, a.a*b.b+a.b*b.a);
        }
        public static comp operator *(double a, comp c)
        {
            return (c.a / a, c.b / a);
        }
        public static comp operator *(comp c, double a)
        {
            return (c.a / a, c.b / a);
        }
        //(/)
        public static comp operator /(comp a, comp b)
        {
            return a*b/(System.Math.Pow(a.a, 2)+ System.Math.Pow(b.a, 2));
        }
        public static comp operator /(comp a, double b)
        {
            return (a.a / b, a.b / b);
        }








        public override string ToString()
        {
            return a + "+" + b + "i";
        }
    }
}
