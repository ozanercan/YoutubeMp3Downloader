﻿using System.Windows.Media;

namespace YoutubeMp3Downloader.Helpers
{
    public static class ColorHelper
    {
        public static Color GetBrushColor(Brush brush)
        {
            return ((SolidColorBrush)brush).Color;
        }
    }
}
