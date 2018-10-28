using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Math
{
    class Program
    {
        static void Main(string[] args)
        {

            //Set A = new Set(new object[] { 1, 2, 3});

            //Set B = new Set(new object[] { 1, A ,3});

            //Pair B = new Pair(1,2);




            //Console.WriteLine(Group.Or(A, C).ToString() + "\n"); // A OR C

            //Console.WriteLine(Group.And(A, C).ToString() + "\n"); // A AND C
            //Console.WriteLine(Set.Multiply(A, new Set(new object[] { })).ToString() + "\n" + "0");// AxC

            //Console.WriteLine(Group.Multiply(A).ToString() + "\n");// AxA

            //Console.WriteLine(Group.Minus(A, C).ToString() + "\n");// A\B

            //Console.WriteLine(Group.SymmetricDifference(A, C).ToString() + "\n");// A∆B
            //Console.WriteLine(Set.P(B));

            Matrix A = new Matrix(new int[,] {
                { 1, 2, 0 },
                { 4, 3, -1 }
            });
            Matrix B = new Matrix(new int[,] {
                { -1, -2, 0 },
                { -4, -3, 1 }
            });
            Matrix AB = A + B;
            Console.Write(AB.ToString());
            Console.ReadKey();


        }
    }
}
