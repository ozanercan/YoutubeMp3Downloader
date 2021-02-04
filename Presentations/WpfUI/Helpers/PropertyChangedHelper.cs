using System.ComponentModel;

namespace YoutubeMp3Downloader.Helpers
{
    public static class PropertyChangedHelper
    {
        #region INotifyPropertyChanged Implementing

        public static void OnPropertyChanged(object sender, string propertyName, PropertyChangedEventHandler propertyChanged)
        {
            if (propertyChanged != null)
            {
                propertyChanged(sender, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion INotifyPropertyChanged Implementing
    }
}
