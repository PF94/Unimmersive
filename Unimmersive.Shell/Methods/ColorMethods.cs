using System;
using System.Drawing;
using SDColor = System.Drawing.Color;
using WMColor = System.Windows.Media.Color;

namespace Unimmersive.Shell.Methods
{
    internal class ColorMethods
    {
        public static SDColor GetDominantColor(Bitmap bmp)
        {

            //Used for tally
            int r = 0;
            int g = 0;
            int b = 0;

            int total = 0;

            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    SDColor clr = bmp.GetPixel(x, y);

                    r += clr.R;
                    g += clr.G;
                    b += clr.B;

                    total++;
                }
            }

            //Calculate average
            r /= total;
            g /= total;
            b /= total;

            return SDColor.FromArgb(r, g, b);
        }

        public static SDColor ChangeColorBrightness(SDColor color, float correctionFactor)
        {
            float red = (float)color.R;
            float green = (float)color.G;
            float blue = (float)color.B;

            if (correctionFactor < 0)
            {
                correctionFactor = 1 + correctionFactor;
                red *= correctionFactor;
                green *= correctionFactor;
                blue *= correctionFactor;
            }
            else
            {
                red = (255 - red) * correctionFactor + red;
                green = (255 - green) * correctionFactor + green;
                blue = (255 - blue) * correctionFactor + blue;
            }

            return SDColor.FromArgb(color.A, (int)red, (int)green, (int)blue);
        }

        public static SDColor IdealTextColor(SDColor bg)
        {
            int nThreshold = 105;
            int bgDelta = Convert.ToInt32((bg.R * 0.299) + (bg.G * 0.587) +
                                          (bg.B * 0.114));

            SDColor foreColor = (255 - bgDelta < nThreshold) ? SDColor.Black : SDColor.White;
            return foreColor;
        }

        public static WMColor SDColorToWMColor(SDColor color)
        {
            return WMColor.FromArgb(color.A, color.R, color.G, color.B);
        }

        public static SDColor WMColorToSDColor(WMColor color)
        {
            return SDColor.FromArgb(color.A, color.R, color.G, color.B);
        }
    }
}
