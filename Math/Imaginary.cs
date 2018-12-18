using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Math
{
    struct imag//Imaginery
    {
        private double b;
        public imag(double r)
        {
            b = r;
        }
        public static implicit operator imag(double d)
        {
            return new imag(d);
        }
        public static implicit operator (double, double) (imag d)
        {
            return (0, d.b);
        }
        public static implicit operator string(imag c)
        {
            return c.ToString();
        }

        //+
        public static comp operator +(comp c, imag a)
        {
            comp b = (0, a.b);
            return c + b;
        }
        public static comp operator +(imag a, comp c)
        {
            comp b = (0, a.b);
            return b + c;
        }

        //*
        public static comp operator *(comp c, imag a)
        {
            comp b = (0, a.b);
            return c + b;
        }
        public static comp operator *(imag a, comp c)
        {
            comp b = (0, a.b);
            return b + c;
        }

        //-
        public static comp operator -(comp c, imag a)
        {
            comp b = (0, a.b);
            return c - b;
        }
        public static comp operator -(imag a, comp c)
        {
            comp b = (0, a.b);
            return b - c;
        }


        public override string ToString()
        {
            return b + "i";
        }
    }
}
