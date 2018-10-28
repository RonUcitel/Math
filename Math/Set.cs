using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Math
{
    class Set
    {
        private int length;
        private object[] data; 
        public Set(object[] inSet)
        {
            data = SortArray(inSet);
            length = data.Length;
        }


        public static Set Multiply(Set A)
        {
            return Multiply(A, A);
        }
        public static Set Multiply(Set A, Set B)
        {
            int count = 0;
            object[] output = new object[A.length * B.length];
            for (int i = 0; i < A.length; i++)
            {
                for (int k = 0; k < B.length; k++)
                {
                    output[count] = new Pair(A.data[i], B.data[k]);
                    count++;
                }
            }
            return new Set(output);
        }

        public static bool IsElement(Set A, object element)
        {
            for (int i = 0; i < A.length; i++)
            {
                if (A.data[i].ToString() == element.ToString())
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsContaned(Set A, Set subSet)
        {
            if (A.length < subSet.length)
            {
                return false;
            }
            for (int i = 0; i < subSet.length; i++)
            {
                    if (!IsElement(A, subSet.data[i]))
                    {
                        return false;
                    }
            }
            return true;
            
        }

        public static bool IsEqual(Set A, Set B)
        {
            if (IsContaned(A,B) && IsContaned(B,A))
            {
                return true;
            }
            return false;
        }


        public static Set P(Set A)
        {
            int n = A.length;
            int count = 1;
            object[] p = new object[(int)System.Math.Pow(2,n)];
            p[0] = new Set(new object[] { });
            for (int k = 1; k <= n; k++)
            {
                int b = Binom.clac(n, k);
                //k=2
                for (int s = 0; s < b; s++)
                {
                    object[] subSet = new object[k];
                    for (int cell = 0; cell < k; cell++)
                    {
                        if (cell+s >= n)
                        {
                            subSet[cell] = A.data[0];
                        }
                        else
                        {
                            subSet[cell] = A.data[cell + s];
                        }
                    }
                    p[count] = new Set(subSet);
                    count++;
                }
            }




            /*
            for (int k = 0; k <= n; k++)
            {
                for (int j = 0; j < Binom.clac(n,k); j++)
                {
                    //--------------------------------------------------------------
                    object[] g = new object[k];
                    for (int cell = 0; cell < k; cell++)
                    {
                        if (j + cell >= n)
                        {
                            g[cell] = A.data[j + cell];
                        }
                        else
                        {
                            g[cell] = A.data[0];
                        }
                    }
                    p[count] = new Group(g);
                    count++;
                //--------------------------------------------------------------
                }
            }
            */
            return new Set(p);
        }
        public static Set SymmetricDifference(Set A, Set B)
        {
            return (Minus(Or(A, B), And(A, B)));
        }
        public static Set Minus(Set A, Set B)
        {
            object[] progress = new object[A.length];
            int count = 0;
            for (int i = 0; i < A.length; i++)
            {
                for (int k = 0; k < B.length; k++)
                {
                    if (A.data[i].ToString() == B.data[k].ToString())
                    {
                        i++;
                        k = 0;
                    }
                }
                progress[count] = A.data[i];
                count++;
            }

            object[] output = new object[0];
            for (int i = 0; i < progress.Length; i++)
            {
                if (progress[i] != null)
                {
                    output = ArrayAddTab(output);
                    output[output.Length - 1] = progress[i];
                }
            }

            return new Set(output);
        }
        public Set Sort()
        {
            object[] sorted = new object[data.Length];
            int length = 0;
            bool can = true;
            for (int i = 0; i < sorted.Length; i++)
            {
                can = true;
                for (int k = 0; k < i; k++)
                {
                    if (data[i].ToString() == data[k].ToString())
                    {
                        can = false;
                    }
                }
                if (can)
                {
                    sorted[length] = data[i];
                    length++;
                }
            }

            data = new object[length];
            for (int i = 0; i < length; i++)
            {
                data[i] = sorted[i];
            }

            return new Set(data);
        }


        public static Set Or(Set A, Set B)
        {

            A = A.Sort();
            B = B.Sort();
            object[] c = new object[A.length + B.length];
            int i = 0;
            while (i < A.length)
            {
                c[i] = A.data[i];
                i++;
            }

            while (i < (B.length + A.length))
            {
                c[i] = B.data[i-A.length];
                i++;
            }


            //object[] newC = new object[0];
            //for (i = i; i < c.Length; i++)
            //{
            //    if (c[i] != null)
            //    {
            //        newC = ArrayAddTab(newC);
            //        newC[newC.Length - 1] = c[i];
            //    }
            //}

            return new Set(c);
        }


        public static Set And(Set A, Set B)
        {
            
            A = A.Sort();
            B = B.Sort();
            object[] c = new object[System.Math.Max(A.length, B.length)];


            for (int i = 0; i < A.length; i++)
            {
                for (int k = 0; k < B.length; k++)
                {
                    if (A.data[i].ToString() == B.data[k].ToString())
                    {
                        c[i] = A.data[i];
                    }
                }
            }

            object[] newC = new object[0];
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] != null)
                {
                    newC = ArrayAddTab(newC);
                    newC[newC.Length - 1] = c[i];
                }
            }

            return new Set(newC);
        }

        static private object[] ArrayAddTab(object[] input)
        {
            object[] work = new object[input.Length + 1];
            for (int i = 0; i < input.Length; i++)
            {
                work[i] = input[i];
            }
            return work;
        }

        public object[] SortArray(object[] input)
        {
            object[] sorted = new object[input.Length];
            int length = 0;
            bool can = true;
            for (int i = 0; i < sorted.Length; i++)
            {
                can = true;
                for (int k = 0; k < i; k++)
                {
                    if (input[i].ToString() == input[k].ToString())
                    {
                        can = false;
                    }
                }
                if (can)
                {
                    sorted[length] = input[i];
                    length++;
                }
            }

            input = new object[length];
            for (int i = 0; i < length; i++)
            {
                input[i] = sorted[i];
            }

            return input;
        }

        public override string ToString()
        {
            if (data.Length == 0)
            {
                return "{Ø}";
            }

            string output = "{ ";
            for (int i = 0; i < data.Length; i++)
            {
                output += data[i].ToString();
                output += ", ";
            }
            output = DeleteLastTwoChar(output);
            output += " }";
            return output;
        }

        private string DeleteLastTwoChar(string input)
        {
            char[] proc = input.ToCharArray();
            input = "";
            for (int i = 0; i < proc.Length - 2; i++)
            {
                input += proc[i];
            }
            return input;
        }
    }

    struct Binom
    {
        static public int clac(int n, int k)
        {
            return Factorial(n) / (Factorial(k) * Factorial(n - k));
        }

        static private int Factorial(int n)
        {
            int output = 1;
            try
            {
                if (n == 0)
                {
                    return output;
                }

                for (int i = 1; i <= n; i++)
                {
                    output *= i;
                }
            }


            catch
            {
                output = (int)System.Math.Round(System.Math.Sqrt(2 * System.Math.PI * n) * System.Math.Pow((n / System.Math.E), Convert.ToDouble(n))); // Stirling's approximation

                throw;
            }
            
            return output;
        }
    }
}
