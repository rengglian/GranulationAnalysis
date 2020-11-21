using OpenCvSharp;

namespace ImageProcessing.Tools
{
    public class OpenCV
    {
        public static void Sharpen(Mat img)
        {
            float[] data = { 1,  1, 1,
                             1, -8, 1,
                             1,  1, 1 };
            var kernel = new Mat(rows: 3, cols: 3, type: MatType.CV_32FC1, data: data);

            Mat imgLaplacian = img.Clone();
            Cv2.Filter2D(img, imgLaplacian, MatType.CV_32F, kernel);
            Mat sharp = img.Clone(); ;
            img.ConvertTo(sharp, MatType.CV_32F);
            Mat imgResult = sharp - imgLaplacian;
            imgResult.ConvertTo(img, MatType.CV_8UC3);
        }

        public static void HistoEqui(Mat img)
        {
            Cv2.CvtColor(img, img, ColorConversionCodes.BGR2GRAY);
            var clahe = Cv2.CreateCLAHE(2.0, new Size(8, 8));
            clahe.Apply(img, img);

        }

        public static void Binarisation(Mat img)
        {
            // Create binary image from source image
            Cv2.Threshold(img, img, 40, 255, ThresholdTypes.Binary | ThresholdTypes.Otsu);
        }
    }
}
