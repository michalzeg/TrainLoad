using System.Collections.Generic;

namespace StruCal.TrainLoad.Domain.Input
{
    public class StructureGeometry
    {
        public IReadOnlyCollection<Bar> Bars { get; set; }
        public IReadOnlyCollection<Support> Supports { get; set; }
    }
}