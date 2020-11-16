using ImageProcessing.Views;
using Prism.Ioc;
using Prism.Modularity;

namespace ImageProcessing
{
    public class ImageProcessingModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ImageProcessingView>();
        }
    }
}
