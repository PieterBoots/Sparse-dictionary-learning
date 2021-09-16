using System;

public class Matrix
{
    public double[] Values = null;
    readonly int N = 0;

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
            Values[x] = InitValue;
    }

    //----------------------------------

    public static Matrix GetMatrixRandom(int _N, Random rnd)
    {
        Matrix M = new Matrix(_N);

        for (int x = 0; x < M.N * M.N; x++)
            M.Values[x] = rnd.Next(256) - 128;
        M.Normalize();
        return M;
    }

    //----------------------------------

    public static Matrix[] GetMatrixArrayRandom(int _N, Int32 cnt, Random rnd)
    {
        Matrix[] coefs = new Matrix[cnt];
        for (int i = 0; i < cnt; i++)
            coefs[i] = Matrix.GetMatrixRandom(_N, rnd);
        return coefs;
    }

    //----------------------------------

    public static Matrix[] FillRnd(int _N, Int32 cnt, Random rnd, int[,] Example)
    {
        Matrix[] coefs = new Matrix[cnt];
        for (int i = 0; i < cnt; i++)
        {
            coefs[i] = new Matrix(_N);
            int x = rnd.Next(Example.GetLength(0) - _N);
            int y = rnd.Next(Example.GetLength(1) - _N);
            for (int y1 = 0; y1 < _N; y1++)
                for (int x1 = 0; x1 < _N; x1++)

                    coefs[i].Values[x1 + y1 * _N] = Example[x1 + x, y1 + y];
            coefs[i].Normalize();
        }
        return coefs;

    }

    //----------------------------------

    public void MatrixRandom()
    {
        Random rnd = new Random();
        for (int x = 0; x < N * N; x++)
            Values[x] = rnd.Next(256) - 128;
        Normalize();
    }


    //----------------------------------

    public Matrix Negative()
    {
        Matrix M = new Matrix(N);
        for (int x = 0; x < N * N; x++)
            M.Values[x] = -Values[x];
        return M;
    }


    //----------------------------------

    public static Matrix[] GetMatrixArrayEmpty(int _N, Int32 cnt)
    {
        Matrix[] coefs = new Matrix[cnt];
        for (int i = 0; i < cnt; i++)
            coefs[i] = new Matrix(_N, 0);
        return coefs;
    }
    //----------------------------------

    public Boolean AllZero()
    {

        for (int i = 0; i < N; i++)
            if (Values[i] != 0)
                return false;
        return true;
    }

    //----------------------------------

    public void Fill(Double Value)
    {
        for (int x = 0; x < N * N; x++)
            Values[x] = Value;
    }

    //----------------------------------

    public void FillRnd(Random rnd)
    {
        for (int x = 0; x < N * N; x++)
            Values[x] = rnd.Next(256) - 128;
        Normalize();
    }

    //----------------------------------

    public void FillRnd(Random rnd, int[,] Example)
    {
        int x = rnd.Next(Example.GetLength(0) - N);
        int y = rnd.Next(Example.GetLength(1) - N);
        for (int y1 = 0; y1 < N; y1++)
            for (int x1 = 0; x1 < N; x1++)
                Values[x1 + y1 * N] = Example[x1 + x, y1 + y];
        Normalize();
    }

    //----------------------------------

    public void CopyFrom(Matrix M)
    {
        for (int x = 0; x < N * N; x++)
            Values[x] = M.Values[x];
    }

    //----------------------------------

    public Matrix Average()
    {
        Matrix M = new Matrix(N);
        double total = 0;
        for (int x = 0; x < N * N; x++)
            total += Values[x];
        for (int x = 0; x < N * N; x++)
            M.Values[x] = total / (N * N);
        return M;
    }

    //----------------------------------

    public static double Dot(Matrix a1, Matrix b1)
    {
        double Value = 0;
        for (int x = 0; x < a1.N * a1.N; x++)
            Value += a1.Values[x] * b1.Values[x];
        return Value;
    }

    //----------------------------------

    public Matrix Add(Double A)
    {
        Matrix M = new Matrix(N);
        for (int x = 0; x < N * N; x++)
            M.Values[x] = Values[x] + A;
        return M;
    }

    //----------------------------------

    public static Matrix operator +(Double a1, Matrix b1)
    {
        Matrix M = new Matrix(b1.N);
        for (int x = 0; x < b1.N * b1.N; x++)
            M.Values[x] = b1.Values[x] + a1;
        return M;
    }

    //----------------------------------

    public static Matrix operator +(Matrix a1, double b1)
    {
        Matrix M = new Matrix(a1.N);
        for (int x = 0; x < a1.N * a1.N; x++)
            M.Values[x] = a1.Values[x] + b1;
        return M;
    }

    //----------------------------------

    public static Matrix operator +(Matrix a1, Matrix b1)
    {
        Matrix M = new Matrix(a1.N);
        for (int x = 0; x < a1.N * a1.N; x++)
            M.Values[x] = a1.Values[x] + b1.Values[x];
        return M;
    }

    //----------------------------------

    public static Matrix operator *(Matrix a1, Matrix b1)
    {
        Matrix M = new Matrix(a1.N);
        for (int x = 0; x < a1.N * a1.N; x++)
            M.Values[x] = a1.Values[x] * b1.Values[x];
        return M;
    }

    //----------------------------------

    public static Matrix operator /(Matrix a1, double b1)
    {
        Matrix M = new Matrix(a1.N);
        for (int x = 0; x < a1.N * a1.N; x++)
            M.Values[x] = a1.Values[x] / b1;
        return M;
    }

    //----------------------------------

    public static Matrix operator *(Matrix a1, double b1)
    {
        Matrix M = new Matrix(a1.N);
        for (int x = 0; x < a1.N * a1.N; x++)
            M.Values[x] = a1.Values[x] * b1;
        return M;
    }


    //----------------------------------

    public static Matrix operator *(double a1, Matrix b1)
    {
        Matrix M = new Matrix(b1.N);
        for (int x = 0; x < b1.N * b1.N; x++)
            M.Values[x] = a1 * b1.Values[x];
        return M;
    }

    //----------------------------------

    public static Matrix operator -(Matrix a1, Matrix b1)
    {
        Matrix M = new Matrix(a1.N);
        for (int x = 0; x < a1.N * a1.N; x++)
            M.Values[x] = a1.Values[x] - b1.Values[x];
        return M;
    }

    //----------------------------------        

    public static Matrix operator -(Double a1, Matrix b1)
    {
        Matrix M = new Matrix(b1.N);
        for (int x = 0; x < b1.N * b1.N; x++)
            M.Values[x] = b1.Values[x] - a1;
        return M;
    }


    public static Matrix operator -( Matrix a1)
    {
        Matrix M = new Matrix(a1.N);
        for (int x = 0; x < a1.N * a1.N; x++)
            M.Values[x] = -a1.Values[x];
        return M;
    }
    //----------------------------------

    public static Matrix operator -(Matrix a1, double b1)
    {
        Matrix M = new Matrix(a1.N);
        for (int x = 0; x < a1.N * a1.N; x++)
            M.Values[x] = a1.Values[x] - b1;
        return M;
    }

    //----------------------------------

    public Matrix Sub(Matrix A)
    {
        Matrix M = new Matrix(N);
        for (int x = 0; x < N * N; x++)
            M.Values[x] = Values[x] - A.Values[x];
        return M;
    }

    //----------------------------------

    static public double EuclideanDistance(Matrix a1, Matrix b1)
    {
        double total = 0;
        for (int x = 0; x < a1.N * a1.N; x++)
            total += (a1.Values[x] - b1.Values[x]) * (a1.Values[x] - b1.Values[x]);
        return Math.Sqrt(total);
    }

    //----------------------------------

    static public Matrix Nearest(Matrix Reference, Matrix[] Coefs, ref Int32 Index)
    {
        double min = 999999;
        //int pick = 0;          
       double tmp1;
        double tmp2;
       
        for (int i = 0; i < Coefs.Length; i++)
        {
            double err1 = 0;
            double err2 = 0;
            for (int x = 0; x < Reference.N * Reference.N; x++)
            {
                tmp1 = (Reference.Values[x] - Coefs[i].Values[x]);
                tmp2 = (Reference.Values[x] + Coefs[i].Values[x]);
                err1 += tmp1 * tmp1;
                err2 += tmp2 * tmp2;
            }
            if (err1 < min)
            {
                min = err1;
                Index = i;
            }
            if (err2 < min)
            {
                min = err2;
                Index = i;
            }
        }
        return Coefs[Index];
    }

    //----------------------------------

    static public Matrix MaxDot(Matrix Reference, Matrix[] Coefs, ref Int32 Index)
    {
        double max = 0;      
        double value = 0;     
        for (int i = 0; i < Coefs.Length; i++)
        {
            value =Math.Abs( Matrix.Dot(Reference, Coefs[i]));
            if (value>max)
            {
                max = value;
                Index = i;
            }           
        }
        return Coefs[Index];
    }

    //----------------------------------

    static public Matrix Sign(Matrix Reference, Matrix Coefs)
    {
          
        double tmp1;
        double tmp2;
        double err1 = 0;
        double err2 = 0;

        for (int x = 0; x < Reference.N * Reference.N; x++)
        {
            tmp1 = (Reference.Values[x] - Coefs.Values[x]);
            tmp2 = (Reference.Values[x] + Coefs.Values[x]);
            err1 += tmp1 * tmp1;
            err2 += tmp2 * tmp2;
        }

        if (err1 < err2)
            return Reference;
        else
            return -Reference;                         
    }
    
    //----------------------------------

    static public Matrix DotMinimumEuclideanDistance(Matrix Reference, Matrix[] Coefs, ref Int32 Index)
    {
        double min = 9999999999;      
        double value = 0;     
        for (int i = 0; i < Coefs.Length; i++)
        {
           value = Matrix.Dot(Reference, Coefs[i]);
           double err = EuclideanDistance(value * Coefs[i] , Reference);
            if (err<min)
            {
                min = err;
                Index = i;
            }           
        }
        return Coefs[Index];
    }

    //----------------------------------

    public Matrix Mul(Double A)
    {
        Matrix M = new Matrix(N);
        for (int x = 0; x < N * N; x++)
            M.Values[x] = Values[x] * A;
        return M;
    }


    //----------------------------------

    public Matrix MinMax()
    {
        double min = 255;
        double max = 0;
        double avg = 0;
        double cnt = 0;
        Matrix M = new Matrix(N);
        for (int x = 0; x < N * N; x++)
        {
            avg += Values[x];
            if (Values[x] > max)
                max = Values[x];
            if (Values[x] < min)
                min = Values[x];
            cnt += 1;
        }
        avg /= cnt;
        double d = 0;
        if (Math.Abs(avg - min) > d)
            d = Math.Abs(avg - min);
        if (Math.Abs(avg - max) > d)
            d = Math.Abs(avg - max);
        for (int x = 0; x < N * N; x++)
            M.Values[x] = 128 + (Values[x] - avg) * 127 / d;
        return M;
    }
    //----------------------------------

    public void Normalize()
    {
        double avg;
        double total = 0;
        for (int x = 0; x < N * N; x++)
            total += Values[x];
        avg = total / (N * N);
        double rangetotal = 0;

        for (int x = 0; x < N * N; x++)
            rangetotal += (Values[x] - avg) * (Values[x] - avg);
        double maxrange = Math.Sqrt(rangetotal);
        if (maxrange == 0)
            for (int x = 0; x < N * N; x++)
                Values[x] = 0;
        else
            for (int x = 0; x < N * N; x++)
                Values[x] = (Values[x] - avg) / maxrange;
    }

    //----------------------------------

    public Matrix GetNormalized()
    {
        Matrix M = new Matrix(N);
        double avg;
        double total = 0;
        for (int x = 0; x < N * N; x++)
            total += Values[x];
        avg = total / (N * N);
        double rangetotal = 0;

        for (int x = 0; x < N * N; x++)
            rangetotal += (Values[x] - avg) * (Values[x] - avg);
        double maxrange = Math.Sqrt(rangetotal);
        if (maxrange == 0)
            for (int x = 0; x < N * N; x++)
                M.Values[x] = 0;
        else
            for (int x = 0; x < N * N; x++)
                M.Values[x] = (M.Values[x] - avg) / maxrange;
        return M;
    }
}
