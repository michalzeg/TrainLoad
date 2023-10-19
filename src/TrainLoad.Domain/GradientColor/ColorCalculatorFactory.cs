namespace StruCal.TrainLoad.Domain.GradientColor
{
    public class ColorCalculatorFactory : IColorCalculatorFactory
    {
        private readonly IGradient _gradient;

        public ColorCalculatorFactory(IGradient gradient)
        {
            _gradient = gradient;
        }

        public IColorCalculator GetColorCalculator(double max, double min)
        {
            return new BaseColorCalculator(_gradient, max, min);
        }
    }
}