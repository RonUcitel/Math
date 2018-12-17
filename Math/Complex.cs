using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace Math
{
    struct Complex
    {
        private double a, b;
        public Complex((double x, double y) value)
        {
            a = value.x;
            b = value.y;
        }
        public static implicit operator Complex(double d)
        {
            return new Complex((d, 0));
        }
        public static implicit operator Complex((double, double) d)
        {
            return new Complex((d.Item1, d.Item2));
        }
        public static implicit operator string(Complex c)
        {
            return c.ToString();
        }

        //+
        public static Complex operator +(Complex c1, Complex c2)
        {
            return (c1.a + c2.a, c1.b + c2.b);
        }

        //-
        public static Complex operator -(Complex c1, Complex c2)
        {
            return (c1.a - c2.a, c1.b - c2.b);
        }



        //+
        public static Complex operator +(Complex c, double a)
        {
            return (c.a + a, c.b);
        }
        public static Complex operator +(double a, Complex c)
        {
            return (c.a + a, c.b);
        }


        //-
        public static Complex operator -(Complex c, double a)
        {
            return (c.a - a, c.b);
        }
        public static Complex operator -(double a, Complex c)
        {
            return (c.a - a, c.b);
        }
        public override string ToString()
        {
            return a + "+" + b + "i";
        }
    }
}
