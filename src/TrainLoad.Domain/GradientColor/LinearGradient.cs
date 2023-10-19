using System.Collections.Generic;
using System.Linq;

namespace StruCal.TrainLoad.Domain.GradientColor
{
    public class LinearGradient : IGradient
    {
        private readonly Dictionary<double, Color> _colors;
        public int Range { get; }

        public LinearGradient(int range = 100)
        {
            Range = range;
            _colors = new Dictionary<double, Color>()
            {
                { 0.00 * range, Color.FromHexString("0000FF") },
                { 0.30 * range, Color.FromHexString("0099FF") },
                { 0.45 * range, Color.FromHexString("00FFFF") },
                { 0.50 * range, Color.FromHexString("00FF00") },
                { 0.55 * range, Color.FromHexString("FFFF00") },
                { 0.70 * range, Color.FromHexString("FF9900") },
                { 1.00 * range, Color.FromHexString("FF0000") }
            };
        }

        public Color ColorAt(int index)
        {
            if (index <= 0)
                return _colors.First().Value;
            else if (index >= Range)
                return _colors.Last().Value;

            var minBoundary = _colors.TakeWhile(e => e.Key <= index).Last();

            var maxBoundary = _colors.SkipWhile(e => e.Key <= index).First();

            var result = CalculateColor(minBoundary.Value, maxBoundary.Value, index, minBoundary.Key, maxBoundary.Key);

            return result;
        }

        private static Color CalculateColor(Color min, Color max, int index, double minRange, double maxRange)
        {
            var denominator = (index - minRange) / (maxRange - minRange);

            var rAverage = min.R + (int)((max.R - min.R) * denominator);
            var gAverage = min.G + (int)((max.G - min.G) * denominator);
            var bAverage = min.B + (int)((max.B - min.B) * denominator);
            var result = Color.FromRGB(rAverage, gAverage, bAverage);
            return result;
        }
    }
}