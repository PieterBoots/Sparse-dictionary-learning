using System;

class Matrix
{
    public double[] Values = null;
    int N = 0;
  
    //----------------------------------

    public Matrix(int _N)
    {
        this.N = _N;
        Values = new double[N * N];
    }

    //----------------------------------

    public Matrix(int _N, double InitValue)
    {
        this.N = _N;
        Values = new double[N * N];
        for (int x = 0; x < N * N; x++)
        {
            Values[x] = InitValue;
        }
    }
    
    //----------------------------------

    public static Matrix GetMatrixRandom(int _N,Random rnd)
    {
        Matrix M=new Matrix(_N);
     
           for (int x = 0; x < M.N * M.N; x++)
        {
            M.Values[x] = rnd.Next(256)-128;
        }
        M.Normalize();
        return M;
    }

    //----------------------------------

    public static Matrix[] GetMatrixArrayRandom(int _N, Int32 cnt,Random rnd)
    {
        Matrix[] coefs = new Matrix[cnt];      
        for (int i = 0; i < cnt; i++)
        {
            coefs[i] = Matrix.GetMatrixRandom(_N,rnd);
        }
        return coefs;
    }

    //----------------------------------

    public void  MatrixRandom()
    {        
        Random rnd = new Random();
        for (int x = 0; x < N* N; x++)
        {
            Values[x] = rnd.Next(256) - 128;
        }
        Normalize();
       
    }

    //----------------------------------

    public static Matrix[] GetMatrixArrayEmpty(int _N, Int32 cnt)
    {
        Matrix[] coefs = new Matrix[cnt];
        for (int i = 0; i < cnt; i++)
        {
            coefs[i] = new Matrix(_N, 0);
        }
        return coefs;
    }
    //----------------------------------

    public  Boolean AllZero()
    {
       
        for (int i = 0; i < N; i++)
        {
            if (Values[i] != 0 )
            {
                return false;
            }
        }
        return true;
    }

    //----------------------------------

    public void Fill(Double Value)
    {                 
        for (int x = 0; x < N * N; x++)
        {
            Values[x] = Value;
        }       
    }

    //----------------------------------

    public void FillRnd(Random rnd)
    {     
        for (int x = 0; x < N * N; x++)
        {
            Values[x] = rnd.Next(256) - 128;
        }
        Normalize();      
    }

    //----------------------------------

    public void FillRnd(Random rnd,int[,] Example)
    {
        int x = rnd.Next(Example.GetLength(0)-N);
        int y = rnd.Next(Example.GetLength(1) - N);
        for (int y1 = 0; y1 < N ; y1++)
        {
            for (int x1 = 0; x1 < N ; x1++)
            {
                Values[x1+y1*N] = Example[x1+x,y1+y];
            }
        }
        Normalize();
    }

    //----------------------------------

    public void CopyFrom(Matrix M)
    {
        for (int x = 0; x < N * N; x++)
        {
            Values[x] = M.Values[x];
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

    //----------------------------------

    public static double Dot(Matrix a1, Matrix b1)
    {
        double Value = 0;
        for (int x = 0; x < a1.N * a1.N; x++)
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
        for (int x = 0; x < a1.N * a1.N; x++)
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

    //----------------------------------        

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

    static public int BestMatch(Matrix Reference, Matrix[] Coefs)
    {
        double min = 999999999;
        int pick = 0;
        double[] r = Reference.Values;
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

    //----------------------------------

    public static double SqrErr(Matrix a1, Matrix b1)
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
        for (int x = 0; x < N * N; x++)
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
   
        for (int x = 0; x < N * N; x++)
        {
            rangetotal = rangetotal + (Values[x] - avg) * (Values[x] - avg);
        }
        double maxrange = Math.Sqrt(rangetotal);
        for (int x = 0; x < N * N; x++)
        {
            Values[x] = (Values[x] - avg) / maxrange;
        }
    }

    //----------------------------------

    public Matrix GetNormalized()
    {
        Matrix M = new Matrix(N);
        double avg = 0;
        double total = 0;
        for (int x = 0; x < N * N; x++)
        {
            total = total + Values[x];
        }
        avg = total / (N * N);
        double rangetotal = 0;
        for (int x = 0; x < N * N; x++)
        {
            rangetotal = rangetotal + (Values[x] - avg) * (Values[x] - avg);
        }
        double maxrange = Math.Sqrt(rangetotal);
        for (int x = 0; x < N * N; x++)
        {
           M.Values[x] = (Values[x] - avg) / maxrange;
        }
        return M;
    }
}

