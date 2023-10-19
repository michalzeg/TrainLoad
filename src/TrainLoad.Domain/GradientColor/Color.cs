using System;

namespace StruCal.TrainLoad.Domain.GradientColor
{
    public class Color
    {
        private const int hex = 16;

        public int R { get; private set; }
        public int G { get; private set; }
        public int B { get; private set; }

        private Color()
        {
        }

        public string GetHexCode()
        {
            var r = CheckLength(R.ToString("X"));
            var g = CheckLength(G.ToString("X"));
            var b = CheckLength(B.ToString("X"));
            var result = r + g + b;
            return result;
        }

        private static string CheckLength(string value)
        {
            if (value.Length == 1)
            {
                return value.Insert(0, "0");
            }
            return value;
        }

        public string GetHexCodeHashed()
        {
            return "#" + GetHexCode();
        }

        public static Color FromRGB(int r, int g, int b)
        {
            var color = new Color();
            color.R = r;
            color.G = g;
            color.B = b;
            return color;
        }

        public static Color FromHexString(string colorNumber)
        {
            var color = new Color();
            var colorTrimmed = colorNumber.Trim('#');
            color.R = Convert.ToInt32(colorTrimmed.Substring(0, 2), hex);
            color.G = Convert.ToInt32(colorTrimmed.Substring(2, 2), hex);
            color.B = Convert.ToInt32(colorTrimmed.Substring(4, 2), hex);
            return color;
        }
    }
}