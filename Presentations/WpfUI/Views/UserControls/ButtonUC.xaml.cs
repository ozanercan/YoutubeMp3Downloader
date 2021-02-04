using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Media;
using YoutubeMp3Downloader.Helpers;
namespace YoutubeMp3Downloader.Views.UserControls
{
    /// <summary>
    /// Interaction logic for ButtonUC.xaml
    /// </summary>
    public partial class ButtonUC : UserControl, INotifyPropertyChanged
    {
        private string _text;
        public ButtonUC()
        {
            InitializeComponent();
        }

        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                PropertyChangedHelper.OnPropertyChanged(this, "Text", PropertyChanged);
            }
        }
        
        public Color GetBackgroundColor { get { return ColorHelper.GetBrushColor(this.Background); } }

        public event PropertyChangedEventHandler PropertyChanged;

        private void userControl_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            this.Background = (Brush)(new SolidColorBrush(Color.FromArgb(255, GetBackgroundColor.R, GetBackgroundColor.G, GetBackgroundColor.B)));
        }

        private void userControl_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            this.Background = (Brush)(new SolidColorBrush(Color.FromArgb(178, GetBackgroundColor.R, GetBackgroundColor.G, GetBackgroundColor.B)));
        }
    }
}
