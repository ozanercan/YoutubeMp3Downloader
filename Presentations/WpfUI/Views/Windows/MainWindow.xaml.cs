using Business.Abstract;
using Business.Concrete.yt_download;
using Core.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfUI.Views.Windows;

namespace WpfUI
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

        private void buttonUC_Close_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private async void buttonUC_Download_PreviewMouseLeftButtonUpAsync(object sender, MouseButtonEventArgs e)
        {
            string videoId = FindVideoIdByUrl(textBox_VideoURL.Text);

            await _convertService.SendToIdAsync(videoId);

            LoadingWindow loadingWindow = new LoadingWindow();

            loadingWindow.ShowDialog();
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
