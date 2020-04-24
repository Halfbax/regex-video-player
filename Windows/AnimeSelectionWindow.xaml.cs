using System;
using System.Windows;
using System.Windows.Controls;


namespace RegexVideoPlayer
{
    /// <summary>
    /// Interaction logic for AnimeSelectionWindow.xaml
    /// </summary>
    public partial class AnimeSelectionWindow : Window
    {
        private Models.Naruto config;

        public AnimeSelectionWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.config = Core.Config.Load(); 
        }

        private void animeSelection_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow(this.config);
            window.Anime = (sender as Button).Name;
            window.Owner = this;
            window.Show();
            this.Hide();
        }

    }
}
