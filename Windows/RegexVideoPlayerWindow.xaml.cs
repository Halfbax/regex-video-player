
using System.Windows;
using RegexVideoPlayer.ViewModel;

namespace RegexVideoPlayer.Windows
{
    /// <summary>
    /// Interaction logic for RegexVideoPlayerWindow.xaml
    /// </summary>
    public partial class RegexVideoPlayerWindow : Window
    {
        public RegexVideoPlayerWindow()
        {
            InitializeComponent();

            this.DataContext = new WindowViewModel(this);
        }
    }
}
