using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Math
{
    class Matrix
    {
        private double[,] x; //i=m=y ; j=n=x

        public int n
        {
            get { return x.GetLength(1); }
        }
        public int m
        {
            get { return x.GetLength(0); }
        }

        public Matrix(double[,] input)
        {
            x = input;
        }

        public double GetValue(int i = 0, int j = 0)
        {
            return x.GetLength(0) + x.GetLength(1) == 0 ? 0 : x[i, j];
        }

        public void SetValue(double value, int i = 0, int j = 0)
        {
            x[i, j] = value;
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
            return new Matrix(new double[0, 0]);
        }

        public static Matrix operator -(Matrix a, Matrix b)
        {
            if (a.m == b.m && a.n == b.n)
            {
                for (int i = 0; i < a.m; i++)
                {
                    for (int j = 0; j < a.n; j++)
                    {
                        a.SetValue(a.GetValue(i, j) - b.GetValue(i, j), i, j);
                    }
                }
                return a;
            }
            return new Matrix(new double[0,0]);
        }

        public static Matrix Exchange(Matrix A, int to, int from)
        {
            if (to >= 0 && from >= 0 && to < A.m && from < A.m)
            {
                double[,] b = new double[A.m, A.n];
                for (int j = 0; j < A.n; j++)
                {
                    b[to, j] = A.GetValue(from, j);
                }
                Matrix B = new Matrix(b);
                return A + B;
            }
            return new Matrix(new double[0, 0]);
        }

        public static Matrix Integrate(Matrix A, double a ,int toRow, double b, int fromRow)
        {
            if (toRow >= 0 && fromRow >= 0 && toRow < A.m && fromRow < A.m)
            {
                double[,] bArray = new double[A.m, A.n];
                for (int j = 0; j < A.n; j++)
                {
                    A.SetValue(a * A.GetValue(toRow, j) + b * A.GetValue(fromRow, j), toRow, j);
                }
                return A;
            }
            return new Matrix(new double[0, 0]);
        }

        public static Matrix operator *(Matrix A, Matrix B)
        {
            if (A.n == B.m)
            {
                double[,] AB = new double[A.m,B.n];
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
            return new Matrix(new double[0,0]);
        }

        public static Matrix operator *(int x, Matrix A)
        {
            for (int i = 0; i < A.m; i++)
            {
                for (int j = 0; j < A.n; j++)
                {
                    A.SetValue(A.GetValue(i, j) * x, i, j);
                }
            }
            return A;
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
