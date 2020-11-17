using Microsoft.Win32;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ImageProcessing.IO
{
    public class ImageReader
    {
        public static Mat Read()
        {

            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                DefaultExt = ".jpg",
                Filter = "JPG Files (*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png"
            };

            Nullable<bool> result = openFileDialog.ShowDialog();

            if (result == true)
            {
                string filename = openFileDialog.FileName;
                Mat srcImage;

                srcImage = new Mat(filename, ImreadModes.AnyDepth | ImreadModes.AnyColor);

                return srcImage;
            }
            return null;
        }
    }
}
