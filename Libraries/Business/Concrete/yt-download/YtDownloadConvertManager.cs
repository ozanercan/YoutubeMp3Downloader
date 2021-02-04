using Business.Abstract;
using Core.Helpers;
using HtmlAgilityPack;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Business.Concrete.yt_download
{
    public class YtDownloadConvertManager : IConvertService
    {
        private string url = "https://www.yt-download.org/api/button/mp3/";

        HtmlWeb web = new HtmlWeb();

        public async Task SendToIdAsync(string videoId)
        {
            try
            {
                string requestUrl = Path.Combine(url, videoId);

                var htmlDoc = await web.LoadFromWebAsync(requestUrl);

                var node = htmlDoc.DocumentNode.SelectSingleNode("//a");

                string downloadUrl = node.Attributes["href"].Value;



                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                string downloadFolderPath = Path.Combine(desktopPath, "Downloaded Musics");

                Directory.CreateDirectory(downloadFolderPath);

                string musicName = await GetMusicNameAsync(videoId) + ".mp3";

                string downloadPath = Path.Combine(downloadFolderPath, musicName);

                DownloadHelper.Download(downloadUrl, downloadPath);
            }
            catch (Exception)
            {
            }
            
        }

        private async Task<string> GetMusicNameAsync(string videoId)
        {
            try
            {
                string url = "https://www.youtube.com/watch?v=" + videoId;

                var htmlDoc = await web.LoadFromWebAsync(url);

                var node = htmlDoc.DocumentNode.SelectSingleNode("//title");

                return node.InnerText.Replace("- YouTube", "").Trim();
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
