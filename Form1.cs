﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int N = 8;
        int CoefsN =64;
        int KSVD_Depth =64;
   
        //----------------------------------

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            int rib = (int)Math.Sqrt(CoefsN);           
            if (rib * rib < CoefsN)
            {
                rib = (int)Math.Sqrt(CoefsN) + 1;
            }

            Bitmap bmp = (Bitmap)Bitmap.FromFile("Kawasaki_Valencia_2007_09_320x240.bmp");               
            Bitmap Coefsbmp = new Bitmap((N+1) * rib, (N+1) * rib, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            
            PicImage.Image = Helper.scaler(bmp, 2, InterpolationMode.NearestNeighbor);
         
           
            PicCoefs.Image = Helper.scaler(Coefsbmp, 256,256, InterpolationMode.NearestNeighbor);                                            
    
            int[,] dat = new int[320, 240];
            for (points A = new points(320, 240); A.DoIt; A.Inc())
            {
                dat[A.x, A.y] = (int)(bmp.GetPixel(A.x, A.y).GetBrightness() * 255.0);
            }
            Random rnd = new Random();
            Matrix[] coefs = Matrix.GetMatrixArrayRandom(N, CoefsN,rnd);
            Matrix[] CoefsCopy = Matrix.GetMatrixArrayRandom(N, CoefsN,rnd);

            Matrix PatchOut = null;                          
       
            for (int repeat = 0; repeat < 200; repeat++)
            {
                for (points A = new points(320 / N, 240 / N); A.DoIt; A.Inc())
                {
                    Matrix PatchIn = GetPatch(A,dat);
                    for (int p = 0; p < KSVD_Depth; p++)
                    {
                        if (p == 0)
                        {
                            PatchOut = PatchIn.Average();
                        }
                        else
                        {
                            Matrix Norm = PatchIn - PatchOut;
                            int pick = Matrix.BestMatch(Norm, coefs);
                            double pickvalue = Matrix.Dot(Norm, coefs[pick]);
                             PatchOut = (coefs[pick] * pickvalue) + PatchOut;
                          
                            //FeedBack
                             Norm.Normalize();
                            CoefsCopy[pick] = CoefsCopy[pick] + Norm * pickvalue;
                        }
                    }
                    DrawPatch(A, bmp, PatchOut);
                }

                PicImage.Image = Helper.scaler(bmp, 2, InterpolationMode.NearestNeighbor);
                PicImage.Refresh();

                for (int i = 0; i < coefs.Length; i++)
                {               
                    CoefsCopy[i].Normalize();
                    coefs[i].CopyFrom(CoefsCopy[i]);                  
                    CoefsCopy[i].FillRnd(rnd);
                }

                DrawCoefs(Coefsbmp, coefs,rib);                            
            }     
        }

        //----------------------------------

        private void DrawCoefs(Bitmap Coefsbmp, Matrix[] coefs,int rib)
        {       
            int i = 0;
            for (int x = 0; x < rib; x++)
            {
                for (int y = 0; y < rib; y++)
                {
                    for (int x2 = 0; x2 < N; x2++)
                    {
                        for (int y2 = 0; y2 < N; y2++)
                        {
                            if (i < coefs.Length)
                            {
                                int c = (int)(128 + coefs[i].Values[x2 + y2 * N] * (127 + 32));
                                if (c < 0) { c = 0; }
                                if (c > 255) { c = 255; }
                                Coefsbmp.SetPixel(x * (N + 1) + x2, y * (N + 1) + y2, Color.FromArgb(255, c, c, c));
                            }
                           
                        }
                    }
                    i = i + 1;
                }
            }       
            PicCoefs.Image = Helper.scaler(Coefsbmp, 256,256, InterpolationMode.NearestNeighbor);          
            PicCoefs.Refresh();
        }

        //----------------------------------

        private Matrix GetPatch(points A,int[,] dat )
        {
            Matrix M = new Matrix(N);
            for (int x = 0; x < N; x++)
            {
                for (int y = 0; y < N; y++)
                {
                    M.Values[x + y * N] = dat[A.x * N + x, A.y * N + y];
                }
            }
            return M;
        }

        //----------------------------------

        private void DrawPatch(points A,Bitmap bmp, Matrix Outp )
        {
            for (int x = 0; x < N; x++)
            {
                for (int y = 0; y < N; y++)
                {
                    int c = (int)(Outp.Values[x + y * N]);
                    if (c < 0) { c = 0; }
                    if (c > 255) { c = 255; }
                    bmp.SetPixel(A.x * N + x, A.y * N + y, Color.FromArgb(255, c, c, c));
                }
            }
        }

        //----------------------------------
    }
}