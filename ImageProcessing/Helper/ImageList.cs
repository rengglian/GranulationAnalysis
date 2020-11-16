using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ImageProcessing.Helper
{
    public class ImageList
    {
        public string Title { get; set; } = "";
        public BitmapImage ImageData { get; set; } = new BitmapImage();
        public ImageList(string title, BitmapImage imageData)
        {
            Title = title;
            ImageData = imageData;
        }
        public override string ToString()
        {
            return Title;
        }
    }
}
