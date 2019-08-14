using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;

class Helper
{

    //----------------------------------

    static public Bitmap scaler(Bitmap Source, Int32 Factor, InterpolationMode interpolationMode)
    {
        var Target = new Bitmap(Source.Width * Factor, Source.Height * Factor, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
        var graphics = Graphics.FromImage(Target);
        graphics.CompositingMode = CompositingMode.SourceCopy;
        graphics.CompositingQuality = CompositingQuality.HighSpeed;
        graphics.InterpolationMode = interpolationMode;
        graphics.DrawImage(Source,
            new Rectangle(0, 0, Target.Width, Target.Height),
            new Rectangle(0, 0, Source.Width, Source.Height),
            GraphicsUnit.Pixel);
        return Target;
    }

    //----------------------------------

    static public Bitmap scaler(Bitmap Source, Int32 NewWidth,Int32 NewHeight, InterpolationMode interpolationMode)
    {
        var Target = new Bitmap(NewWidth, NewHeight, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
        var graphics = Graphics.FromImage(Target);
        graphics.CompositingMode = CompositingMode.SourceCopy;
        graphics.CompositingQuality = CompositingQuality.HighSpeed;
        graphics.InterpolationMode = interpolationMode;
        graphics.DrawImage(Source,
            new Rectangle(0, 0, Target.Width, Target.Height),
            new Rectangle(0, 0, Source.Width, Source.Height),
            GraphicsUnit.Pixel);
        return Target;
    }

    //----------------------------------
}

  class points
  {
    public int width;
    public int height;
    public int index;

    public points(int awidth, int aheight)
    {
      width = awidth;
      height = aheight;
    }

    public void Inc()
    {
      index = index + 1;
    }


    public int max
    {
      get { return width * height; }
    }

    public int x
    {
      get { return index % width; }
    }

    public int y
    {
      get { return index / width; }
    }

    public Boolean DoIt
    {
      get
      {
        return index < max;
      }
    }
  }

