using System.Windows.Media;

namespace WpfUI.Helpers
{
    public static class ColorHelper
    {
        public static Color GetBrushColor(Brush brush)
        {
            return ((SolidColorBrush)brush).Color;
        }
    }
}
