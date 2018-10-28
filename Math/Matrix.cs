using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Math
{
    enum Expressions
    {
        emptySet = -2,
        error = -1
    }
    class Matrix
    {
        private int[,] x; //i=m=y ; j=n=x

        public int n
        {
            get { return x.GetLength(1); }
        }
        public int m
        {
            get { return x.GetLength(0); }
        }

        public Matrix(int[,] input)
        {
            x = input;
        }

        public int GetValue(int i = 0, int j = 0)
        {
            return x.GetLength(0) + x.GetLength(1) == 0 ? (int)Expressions.error : x[i, j];
        }
        public void SetValue(int index, int i = 0, int j = 0)
        {
            x[i, j] = index;
        }

        public static Matrix operator +(Matrix a, Matrix b)
        {
            if (a.m == b.m && a.n == b.n)
            {
                for (int i = 0; i < a.m; i++)
                {
                    for (int j = 0; j < a.n; j++)
                    {
                        a.SetValue(a.GetValue(i, j) + b.GetValue(i, j), i, j);
                    }
                }
                return a;
            }
            return new Matrix(new int[,] { /*{ (int)Expressions.error }*/{ 0 }, { 0 } });
        }

        public static Matrix operator *(Matrix A, Matrix B)
        {
            if (A.n == B.m)
            {
                int[,] AB = new int[A.m,B.n];
                for (int i = 0; i < B.n; i++)
                {
                    for (int j = 0; j < A.m; j++)
                    {
                        for (int k = 0; k < A.n; k++)
                        {
                            AB[i, j] += A.GetValue(i, k) * B.GetValue(k, j);
                        }
                    }
                }
                return new Matrix(AB);
            }
            return new Matrix(new int[,] { /*{ (int)Expressions.error }*/{ 0 }, { 0 } });
        }

        public override string ToString()
        {
            string end = "";
            for (int i = 0; i < this.m; i++)
            {
                for (int j = 0; j < this.n; j++)
                {
                    end += Convert.ToString(this.GetValue(i, j)) + " ";
                }
                end+="\n";
            }
            return end;
        }
    }
}
