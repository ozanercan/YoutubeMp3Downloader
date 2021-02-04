using Business.Abstract;
using Business.Concrete.yt_download;
using System.Windows;
using System.Windows.Input;
using YoutubeMp3Downloader.Views.Windows;

namespace YoutubeMp3Downloader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IConvertService _convertService;
        public MainWindow()
        {
            InitializeComponent();
            _convertService = new YtDownloadConvertManager();
        }

        LoadingWindow loadingWindow = new LoadingWindow();

        private void buttonUC_Close_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private async void buttonUC_Download_PreviewMouseLeftButtonUpAsync(object sender, MouseButtonEventArgs e)
        {
            if (textBox_VideoURL.Text.IndexOf("youtube") == -1)
            {
                MessageBox.Show("Please copy the link as requested. Example\nhttps://www.youtube.com/watch?v=LaQj636PJh0", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                string videoId = FindVideoIdByUrl(textBox_VideoURL.Text);

                await _convertService.SendToIdAsync(videoId);


                loadingWindow.ShowDialog();
            }
        }

        private string FindVideoIdByUrl(string url)
        {
            string lastUrl = url;

            int videoFieldIndex = url.IndexOf("?v=") + 3;

            int andOperatorIndex = url.IndexOf("&");

            if (andOperatorIndex != -1)
                lastUrl = lastUrl.Remove(andOperatorIndex);

            lastUrl = lastUrl.Remove(0, videoFieldIndex);

            return lastUrl;
        }
    }
}
