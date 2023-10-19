namespace StruCal.TrainLoad.Domain.GradientColor
{
    public interface IColorCalculatorFactory
    {
        IColorCalculator GetColorCalculator(double max, double min);
    }
}