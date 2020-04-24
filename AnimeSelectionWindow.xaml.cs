using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NarutoViewer
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
            Console.WriteLine("set");
            window.Owner = this;
            window.Show();
            this.Hide();
        }

    }
}
