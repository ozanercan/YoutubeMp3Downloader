using System;
using System.Net;

namespace Core.Helpers
{
    public static class DownloadHelper
    {
        private static WebClient webClient = new WebClient();

        public static DownloadStates DownloadState;

        public static void Download(string url, string downloadFolderPath)
        {
            webClient.DownloadFileCompleted += WebClient_DownloadFileCompleted;
            webClient.DownloadProgressChanged += WebClient_DownloadProgressChanged;
            webClient.DownloadFileAsync(new Uri(url), downloadFolderPath);
        }

        private static void WebClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            DownloadState = DownloadStates.Downloading;
        }

        private static void WebClient_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            DownloadState = DownloadStates.Downloaded;
        }
    }
}
