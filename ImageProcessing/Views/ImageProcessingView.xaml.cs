using GranulationAnalysis.Core.Prism;
using ImageProcessing.ControlViews;
using System.Windows.Controls;

namespace ImageProcessing.Views
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    /// 
    [DependentView(typeof(OpenControlView), RegionNames.ContentRegionTop)]
    [DependentView(typeof(ClaheControlView), RegionNames.ContentRegionTop)]
    [DependentView(typeof(SharpenControlView), RegionNames.ContentRegionTop)]
    [DependentView(typeof(BinarizationControlView), RegionNames.ContentRegionTop)]
    public partial class ImageProcessingView : UserControl, ISupportDataContext
    {
        public ImageProcessingView()
        {
            InitializeComponent();
        }
    }
}