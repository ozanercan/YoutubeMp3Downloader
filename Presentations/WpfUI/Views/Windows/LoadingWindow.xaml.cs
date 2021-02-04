using Core.Helpers;
using SpeechLib;
using System;
using System.Collections.Generic;
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

namespace YoutubeMp3Downloader.Views.Windows
{
    /// <summary>
    /// Interaction logic for Loading.xaml
    /// </summary>
    public partial class LoadingWindow : Window
    {
        public LoadingWindow()
        {
            InitializeComponent();
        }

        SpVoice voice = new SpVoice();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                voice.Speak("Music downloading, please wait.", SpeechVoiceSpeakFlags.SVSFDefault);

                Task.Run(() =>
                {
                    for (; ; )
                    {
                        if (DownloadHelper.DownloadState == DownloadStates.Downloaded)
                        {
                            voice.Speak("Music downloaded.", SpeechVoiceSpeakFlags.SVSFDefault);

                            this.Dispatcher.Invoke(() =>
                            {
                                this.Close();
                            });
                            break;
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
