
using System.Windows;
using RegexVideoPlayer.ViewModel;
using RegexVideoPlayer.Core;

namespace RegexVideoPlayer.Windows
{
    /// <summary>
    /// Interaction logic for RegexVideoPlayerWindow.xaml
    /// </summary>
    public partial class RegexVideoPlayerWindow : Window
    {
        private Config config;

        public RegexVideoPlayerWindow()
        {
            InitializeComponent();

            this.DataContext = new WindowViewModel(this);
        }

        private void AppWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.config = new Config();
        }
    }
}
