using StruCal.TrainLoad.Domain.Input;
using System.Collections.Generic;

namespace StruCal.TrainLoad.Domain.Output
{
    public class TrainLoadResult
    {
        public double MaxAbsoluteDisplacement { get; set; }
        public IEnumerable<TimeResult> TimeResults { get; set; }
        public TimeSettings TimeSettings { get; set; }
    }
}