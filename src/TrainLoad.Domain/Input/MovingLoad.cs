using System.Collections.Generic;

namespace StruCal.TrainLoad.Domain.Input
{
    public class MovingLoad
    {
        public double Speed { get; set; }
        public IReadOnlyCollection<MovingForce> Forces { get; set; }
    }
}