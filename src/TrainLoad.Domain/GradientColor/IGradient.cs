namespace StruCal.TrainLoad.Domain.GradientColor
{
    public interface IGradient
    {
        Color ColorAt(int index);

        int Range { get; }
    }
}