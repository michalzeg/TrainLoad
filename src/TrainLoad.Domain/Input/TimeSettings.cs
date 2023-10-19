using FEM2DDynamics.Solver;
using StruCal.TrainLoad.Shared.Utils;

namespace StruCal.TrainLoad.Domain.Input
{
    public class TimeSettings
    {
        public double StartTime { get; set; }
        public double EndTime { get; set; }
        public double DeltaTime { get; set; }
        public double DeltaTimeResults { get; set; }

        public DynamicSolverSettings ToDynamicSolverSettings(double dampingRatio)
        {
            return new DynamicSolverSettings
            {
                DampingRatio = dampingRatio,
                StartTime = StartTime,
                EndTime = EndTime,
                DeltaTime = DeltaTime,
            };
        }

        public IEnumerable<double> GetTimeRange()
        {
            var result = TimeRange.GetRange(StartTime, EndTime, DeltaTimeResults);
            return result;
        }
    }
}