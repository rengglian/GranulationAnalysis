using ImageProcessing.Helper;
using ImageProcessing.Specimen;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ImageProcessing.ViewModels
{
    public class ImageProcessingViewModel : BindableBase
    {
        private readonly Dictionary<string, SpecimenImage> images;

        private ObservableCollection<ImageList> imgList;
        public ObservableCollection<ImageList> ImgList
        {
            get { return imgList; }
            set { SetProperty(ref imgList, value); }
        }

        private ImageList selectedImage { get; set; }
        public ImageList SelectedImage
        {
            get { return this.selectedImage; }
            set { this.selectedImage = value; }
        }

        private ImageList selectedImageA { get; set; }
        public ImageList SelectedImageA
        {
            get { return this.selectedImageA; }
            set { this.selectedImageA = value; }
        }

        public DelegateCommand<string> OpenImageCommand { get; set; }
        public DelegateCommand<string> SharpenImageCommand { get; private set; }
        public DelegateCommand DeleteCommand { get; private set; }

        public ImageProcessingViewModel()
        {
            OpenImageCommand = new DelegateCommand<string>(OpenImageHandler);
            SharpenImageCommand = new DelegateCommand<string>(SharpenImageHandler);
            DeleteCommand = new DelegateCommand(DeleteHandler);

            ImgList = new ObservableCollection<ImageList>();
            images = new Dictionary<string, SpecimenImage>();
        }

        private void OpenImageHandler(string src)
        {
            if (!images.ContainsKey(src))
            {
                images.Add(src, new SpecimenImage());
            }
            else
            {
                images[src] = new SpecimenImage();
            }
            ImgList.Add(new ImageList(src, images[src].GetBitmapImage()));
        }
        private void SharpenImageHandler(string src)
        {
            if (!images.ContainsKey(src))
            {
                images.Add(src, new SpecimenImage(images[SelectedImageA.Title].ImageMat));
            }
            else
            {
                images[src] = new SpecimenImage(images[SelectedImageA.Title].ImageMat);
            }
            images[src].Sharpen();
            ImgList.Add(new ImageList(src, images[src].GetBitmapImage()));
        }
        private void DeleteHandler()
        {

        }
    }
}
