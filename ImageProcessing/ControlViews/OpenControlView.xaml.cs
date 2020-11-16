using GranulationAnalysis.Core.Prism;
using System.Windows.Controls;

namespace ImageProcessing.ControlViews
{
    /// <summary>
    /// Interaction logic for OpenControlView.xaml
    /// </summary>
    public partial class OpenControlView : UserControl, ISupportDataContext
    {
        public OpenControlView()
        {
            InitializeComponent();
            SetResourceReference(StyleProperty, typeof(UserControl));
        }
    }
}
