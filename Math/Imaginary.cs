using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Math
{
    struct Imaginary
    {
        private double b;
        public Imaginary(double r)
        {
            b = r;
        }
        public static implicit operator Imaginary(double d)
        {
            return new Imaginary(d);
        }
        public static implicit operator (double, double) (Imaginary d)
        {
            return (0, d.b);
        }
        public static implicit operator string(Imaginary c)
        {
            return c.ToString();
        }

        //+
        public static Complex operator +(Complex c, Imaginary a)
        {
            Complex b = (0, a.b);
            return c + b;
        }
        public static Complex operator +(Imaginary a, Complex c)
        {
            Complex b = (0, a.b);
            return b + c;
        }

        //-
        public static Complex operator -(Complex c, Imaginary a)
        {
            Complex b = (0, a.b);
            return c - b;
        }
        public static Complex operator -(Imaginary a, Complex c)
        {
            Complex b = (0, a.b);
            return b - c;
        }


        public override string ToString()
        {
            return b + "i";
        }
    }
}
