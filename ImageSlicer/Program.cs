using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageSlicer
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2) Console.WriteLine("Usage: 'ImageSlicer Filename.png 100'. 100 is height of part in pixels.");

            string filename = args[0];
            Bitmap bm = new Bitmap(filename);
            int height = Int32.Parse(args[1]);

            decimal numSlices = bm.Height / (decimal) height;
            for (int i = 0; i < numSlices; ++i)
            {
                Console.WriteLine("Slicing part: " + i);
                var yStart = height * i;
                if (yStart + height > bm.Height)
                    height = bm.Height - yStart;

                using (var slice = bm.Clone(new Rectangle(0, yStart, bm.Width, height), bm.PixelFormat))                
                    slice.Save(filename.Substring(0, filename.IndexOf('.')) + "-" + i + ".png");
            }
            
        }
    }
}
