using ImageProcessing.IO;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ImageProcessing.Specimen
{
    public class SpecimenImage
    {
        public Mat ImageMat { get; set; }

        public SpecimenImage()
        {
            ImageMat = ImageReader.Read();
        }
        public BitmapImage GetBitmapImage()
        {
            return Convert(ImageMat.ToBitmap());
        }

        private static BitmapImage Convert(Bitmap bitmap)
        {
            using MemoryStream stream = new MemoryStream();
            bitmap.Save(stream, ImageFormat.Png);

            stream.Position = 0;
            BitmapImage result = new BitmapImage();
            result.BeginInit();

            result.CacheOption = BitmapCacheOption.OnLoad;
            result.StreamSource = stream;
            result.EndInit();
            result.Freeze();

            return result;
        }
    }
}
