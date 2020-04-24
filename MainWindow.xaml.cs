using System;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows;


namespace NarutoViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Models.Naruto config;

        public string Anime = "";

        public MainWindow(Models.Naruto config)
        {
            InitializeComponent();
            this.config = config;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(String.Format("https://naruto-tube.org/{0}-sub-{1:D3}", Anime, 1));

            for (int i = 1; i <= 500; i++)
                listViewEpisodes.Items.Add(i);

            switch(Anime)
            {
                case "shippuuden":
                    listViewEpisodes.SelectedIndex = config.Shippuden.Episode;
                    break;
                case "classic":
                    listViewEpisodes.SelectedIndex = config.Classic.Episode;
                    break;
                default:
                    listViewEpisodes.SelectedIndex = config.Boruto.Episode;
                    break;
            }

            listViewEpisodes.ScrollIntoView(listViewEpisodes.SelectedItem);
        }

        private string getVideoUrlById(int id)
        {
            return extractData(extractData(String.Format("https://naruto-tube.org/{0}-sub-{1:D3}", Anime, id), @"<iframe\s+(?:[^>]*?\s+)?src=([""'])(.*?)\1", 2), @"https?.*?\.mp4");
        }

        private string extractData(string url, string pattern, int grpId = 0)
        {
            string html;
            using (WebClient client = new WebClient())
                html = client.DownloadString(url);
            return Regex.Match(html, pattern).Groups[grpId].Value;
        }

        private void buttonPlay_Click(object sender, RoutedEventArgs e)
        {
            string episode = getVideoUrlById(listViewEpisodes.SelectedIndex + 1);
            webBrowser.Navigate(episode);

            switch (Anime)
            {
                case "shippuuden":
                    this.config.Shippuden.Episode = listViewEpisodes.SelectedIndex;
                    break;
                case "classic":
                    this.config.Classic.Episode = listViewEpisodes.SelectedIndex;
                    break;
                default:
                    this.config.Boruto.Episode = listViewEpisodes.SelectedIndex;
                    break;
            }
            Core.Config.Save(this.config);
        }
    }
}
