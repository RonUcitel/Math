using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Math
{
    class Pair
    {
        private object x, y;
        const int length = 2;
        public Pair(object inx, object iny)
        {
            x = inx;
            y = iny;
        }

        public Set PairToGroup()
        {
            Set a = new Set(new object[] { x });

            Set b = new Set(new object[] { x, y });

            return new Set(new object[] { a, b });
        }
        public Pair Invert()
        {
            return new Pair(y, x);
        }

        public override string ToString()
        {
            return "(" + x.ToString() +"," + y.ToString() + ")";
        }

        public string ToGroupString()
        {
            return PairToGroup().ToString();
        }
    }
}
