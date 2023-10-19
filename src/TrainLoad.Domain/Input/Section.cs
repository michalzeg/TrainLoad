using System.Collections.Generic;

namespace StruCal.TrainLoad.Domain.Input
{
    public class Section
    {
        public IReadOnlyCollection<Perimeter> Perimeters { get; set; }
    }
}