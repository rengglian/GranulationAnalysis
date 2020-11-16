using Prism.Commands;
using Prism.Mvvm;
using System;

namespace ImageProcessing.ViewModels
{
    public class ImageProcessingViewModel : BindableBase
    {
        public DelegateCommand<string> OpenImageCommand { get; set; }

        public ImageProcessingViewModel()
        {
            OpenImageCommand = new DelegateCommand<string>(OpenImageHandler);
        }

        private void OpenImageHandler(string obj)
        {
            throw new NotImplementedException();
        }
    }
}
