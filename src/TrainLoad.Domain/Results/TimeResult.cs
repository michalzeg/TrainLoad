using System.Collections.Generic;

namespace StruCal.TrainLoad.Domain.Output
{
    public class TimeResult
    {
        public double Time { get; private set; }
        public IReadOnlyCollection<MeshColorResult> MeshResults { get; private set; }
        public double Acceleration { get; private set; }

        public static TimeResult GenerateTimeResult(double time, double acceleration, IReadOnlyCollection<MeshColorResult> meshColorResults)
        {
            return new TimeResult
            {
                Time = time,
                MeshResults = meshColorResults,
                Acceleration = acceleration
            };
        }
    }
}