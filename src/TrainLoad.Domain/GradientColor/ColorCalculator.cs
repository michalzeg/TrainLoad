namespace StruCal.TrainLoad.Domain.GradientColor
{
    public class BaseColorCalculator : IColorCalculator
    {
        private readonly IGradient _gradient;
        private readonly double _max;
        private readonly double _min;

        public BaseColorCalculator(IGradient gradient, double max, double min)
        {
            _gradient = gradient;
            _max = max;
            _min = min;
        }

        public string GetColor(double value)
        {
            var valueRange = _max - _min;
            var index = (int)((value - _min) / valueRange * _gradient.Range);

            var color = _gradient.ColorAt(index).GetHexCodeHashed();

            return color;
        }
    }
}