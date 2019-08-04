using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Matrix
    {
        public double[] Values = null;
        int N = 0;
        public int count=0;
        //----------------------------------

        public Matrix(int _N)
        {
            // TODO: Complete member initialization
            this.N = _N;
            Values = new double[N*N];
        }

        //----------------------------------

        public Matrix(int _N, double InitValue)
        {
            // TODO: Complete member initialization
            this.N = _N;
            Values = new double[N*N];
            for (int x = 0; x < N * N; x++)
            {
                Values[x] = InitValue;
            }
        }
        
        //----------------------------------

        public Matrix Average()
        {
            Matrix M = new Matrix(N);
            double total = 0;
            for (int x = 0; x < N * N; x++)
            {
                total = total + Values[x];
            }
            for (int x = 0; x < N * N; x++)
            {
                M.Values[x] = total / (N * N);
            }
            return M;
        }

        public double MaxDelta()
        {
            Matrix M = new Matrix(N);
            double total = 0;
            for (int x = 0; x < N * N; x++)
            {
                total = total + Values[x];
            }
            double max=0;
            for (int x = 0; x < N * N; x++)
            {
                double delta = Math.Abs(Values[x] - (total / (N * N)));
                if (delta > max)
                {
                    max = delta;
                }
            }
            return max;
        }

        //----------------------------------
     
        public static double Dot(Matrix a1,Matrix b1)
        {           
            double Value = 0;
            for (int x = 0; x < a1.N*a1.N; x++)
            {
                Value = Value + a1.Values[x] * b1.Values[x];
            }       
            return Value;            
        }

        //----------------------------------
       
        public Matrix Add(Double A)
        {
            Matrix M = new Matrix(N);
            for (int x = 0; x < N * N; x++)
            {
                M.Values[x] = Values[x] + A;
            }
            return M;
        }

        //----------------------------------

        public static Matrix operator +(Double a1, Matrix b1)
        {
            Matrix M = new Matrix(b1.N);
            for (int x = 0; x < b1.N * b1.N; x++)
            {
                M.Values[x] = b1.Values[x] + a1;
            }
            return M;
        }

        //----------------------------------

        public static Matrix operator +(Matrix a1, double b1)
        {
            Matrix M = new Matrix(a1.N);
            for (int x = 0; x < a1.N*a1.N; x++)
            {                
                    M.Values[x] = a1.Values[x] + b1;                
            }
            return M;
        }

        //----------------------------------

        public static Matrix operator +(Matrix a1, Matrix b1)
        {
            Matrix M = new Matrix(a1.N);
            for (int x = 0; x < a1.N * a1.N; x++)
            {
                M.Values[x] = a1.Values[x] + b1.Values[x];
            }
            return M;
        }

        //----------------------------------

        public static Matrix operator *(Matrix a1, Matrix b1)
        {
            Matrix M = new Matrix(a1.N);
            for (int x = 0; x < a1.N * a1.N; x++)
            {
                M.Values[x] = a1.Values[x] * b1.Values[x];
            }
            return M;
        }

        //----------------------------------

        public static Matrix operator /(Matrix a1, double b1)
        {
            Matrix M = new Matrix(a1.N);
            for (int x = 0; x < a1.N * a1.N; x++)
            {
                M.Values[x] = a1.Values[x] / b1;
            }
            return M;
        }

        //----------------------------------

        public static Matrix operator *(Matrix a1, double b1)
        {
            Matrix M = new Matrix(a1.N);
            for (int x = 0; x < a1.N * a1.N; x++)
            {
                M.Values[x] = a1.Values[x] * b1;
            }
            return M;
        }


        //----------------------------------

        public static Matrix operator *(double a1, Matrix b1)
        {
            Matrix M = new Matrix(b1.N);
            for (int x = 0; x < b1.N * b1.N; x++)
            {
                M.Values[x] = a1 * b1.Values[x];
            }
            return M;
        }

        //----------------------------------

        public static Matrix operator -(Matrix a1, Matrix b1)
        {
            Matrix M = new Matrix(a1.N);
            for (int x = 0; x < a1.N * a1.N; x++)
            {
                M.Values[x] = a1.Values[x] - b1.Values[x];
            }
            return M;
        }

        public static Matrix operator -(Double a1, Matrix b1)
        {
            Matrix M = new Matrix(b1.N);
            for (int x = 0; x < b1.N * b1.N; x++)
            {
                M.Values[x] = b1.Values[x] - a1;
            }
            return M;
        }

        //----------------------------------

        public static Matrix operator -(Matrix a1, double b1)
        {
            Matrix M = new Matrix(a1.N);
            for (int x = 0; x < a1.N * a1.N; x++)
            {
                M.Values[x] = a1.Values[x] - b1;
            }
            return M;
        }

        //----------------------------------

        public Matrix Sub(Matrix A)
        {
            Matrix M = new Matrix(N);
            for (int x = 0; x < N * N; x++)
            {
                M.Values[x] = Values[x] - A.Values[x];
            }
            return M;
        }

        //----------------------------------

        static public int BestMatch(Matrix Reference,Matrix[] Coefs)
        {
            double min = 999999999;
            int pick = 0;
            double[] r=Reference.Values;
            double dot = 0;
            double err = 0;
            double[] cf = Coefs[0].Values; ;
            double tmp = 0;

            for (int i = 0; i < Coefs.Length; i++)
            {
                cf = Coefs[i].Values;
                for (int x = 0; x < Reference.N * Reference.N; x++)
                {
                    dot = dot + r[x] * cf[x];
                }
                err = 0;
                for (int x = 0; x < Reference.N * Reference.N; x++)
                {
                    tmp = (r[x] - cf[x] * dot);
                    err = err + tmp * tmp;                                    
                }
                if (err < min)
                {
                    min = err;
                    pick = i;
                }
            }
            return pick;
        }

        //static public int BestMatch(Matrix Reference, Matrix[] Coefs)
        //{
        //    double min = 999999999;
        //    int pick = 0;
        //    for (int i = 0; i < Coefs.Length; i++)
        //    {
        //        Matrix b1 = Coefs[i];

        //        double dot = Matrix.Dot(Reference, Coefs[i]);
        //        double err = Matrix.Root(Reference, Coefs[i] * dot);
        //        if (err < min)
        //        {
        //            min = err;
        //            pick = i;
        //        }
        //    }
        //    return pick;
        //}

        //----------------------------------

        public static double SqrErr(Matrix a1,Matrix b1)
        {
            double Err = 0;
            for (int x = 0; x < a1.N * a1.N; x++)
            {
                Err = Err + (a1.Values[x] - b1.Values[x]) * (a1.Values[x] - b1.Values[x]);                                         
            }
            return Err;
        }

        //----------------------------------

        public Matrix Mul(Double A)
        {
            Matrix M = new Matrix(N);
            for (int x = 0; x < N*N; x++)
            {
                M.Values[x] = Values[x] * A;
            }
            return M;
        }

        //----------------------------------

        public void Normalize()
        {
            double avg = 0;
            double total = 0;
            for (int x = 0; x < N * N; x++)
            {
                total = total + Values[x];
            }
            avg = total / (N * N);
            double rangetotal = 0;
            for (int x = 0; x < N*N; x++)
            {
                rangetotal = rangetotal + (Values[x] - avg) * (Values[x] - avg);
            }
            double maxrange = Math.Sqrt(rangetotal);
            for (int x = 0; x < N * N; x++)
            {
                Values[x] = (Values[x] - avg) / maxrange;
            }
        }
    }
}
