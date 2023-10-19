using StruCal.TrainLoad.Shared.Extensions;

namespace StruCal.TrainLoad.Shared.Utils
{
    public static class TimeRange
    {
        public static IEnumerable<double> GetRange(double startTime, double endTime, double step)
        {
            var time = startTime;
            while (time < endTime || time.IsApproximatelyEqualTo(endTime))
            {
                yield return time;
                time += step;
            }
        }
    }
}