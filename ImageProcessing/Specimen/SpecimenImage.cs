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

        public SpecimenImage(Mat img)
        {
            ImageMat = img.Clone();
        }

        public void Sharpen()
        {
            float[] data = { 1,  1, 1,
                             1, -12, 1,
                             1,  1, 1 };
            var kernel = new Mat(rows: 3, cols: 3, type: MatType.CV_32FC1, data: data);


            Mat imgLaplacian = ImageMat.Clone();
            Cv2.Filter2D(ImageMat, imgLaplacian, MatType.CV_32F, kernel);
            Mat sharp = ImageMat.Clone(); ;
            ImageMat.ConvertTo(sharp, MatType.CV_32F);
            Mat imgResult = sharp - imgLaplacian;
            imgResult.ConvertTo(ImageMat, MatType.CV_8UC3);
            //imgLaplacian.ConvertTo(imgLaplacian, MatType.CV_8UC3);
        }
    }
}
