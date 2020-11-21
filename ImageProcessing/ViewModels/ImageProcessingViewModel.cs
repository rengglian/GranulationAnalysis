using ImageProcessing.Helper;
using ImageProcessing.Tools;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ImageProcessing.ViewModels
{
    public class ImageProcessingViewModel : BindableBase
    {
        private ObservableCollection<SampleImage> imgList;
        public ObservableCollection<SampleImage> ImgList
        {
            get { return imgList; }
            set { SetProperty(ref imgList, value); }
        }

        private SampleImage selectedImage;
        public SampleImage SelectedImage
        {
            get { return selectedImage; }
            set { SetProperty(ref selectedImage, value); }
        }

        private SampleImage selectedImageA;
        public SampleImage SelectedImageA
        {
            get { return selectedImageA; }
            set { SetProperty(ref selectedImageA, value); }
        }

        public DelegateCommand<string> OpenImageCommand { get; set; }
        public DelegateCommand<string> ClaheImageCommand { get; private set; }
        public DelegateCommand<string> SharpenImageCommand { get; private set; }
        public DelegateCommand<string> BinarizationImageCommand { get; private set; }
        public DelegateCommand<int?> DeleteCommand { get; set; }

        public ImageProcessingViewModel()
        {
            OpenImageCommand = new DelegateCommand<string>(OpenImageHandler);
            ClaheImageCommand = new DelegateCommand<string>(ClaheImageHandler);
            SharpenImageCommand = new DelegateCommand<string>(SharpenImageHandler);
            BinarizationImageCommand = new DelegateCommand<string>(BinarizationImageHandler);
            DeleteCommand = new DelegateCommand<int?>(DeleteHandler);

            ImgList = new ObservableCollection<SampleImage>();
        }
        private void OpenImageHandler(string src)
        {
            ImgList.Add(new SampleImage());
        }

        private void ClaheImageHandler(string src)
        {
            var test = (SampleImage)SelectedImageA.Clone();
            test.Description = src;
            OpenCV.HistoEqui(test.ImageMat);
            test.Update();
            ImgList.Add(test);
        }

        private void SharpenImageHandler(string src)
        {
            var test = (SampleImage)SelectedImageA.Clone();
            test.Description = src;
            OpenCV.Sharpen(test.ImageMat);
            test.Update();
            ImgList.Add(test);
        }

        private void BinarizationImageHandler(string src)
        {
            var test = (SampleImage)SelectedImageA.Clone();
            test.Description = src;
            OpenCV.Binarisation(test.ImageMat);
            test.Update();
            ImgList.Add(test);
        }
        private void DeleteHandler(int? item)
        {
            if (item >= 0)
            {
                ImgList.RemoveAt((int)item);
            }
        }
    }
}
