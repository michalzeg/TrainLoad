using System.Collections.Generic;

namespace StruCal.TrainLoad.Domain.Input
{
    public class TrainLoadInput
    {
        public StructureGeometry StructureGeometry { get; set; }
        public IReadOnlyCollection<VertexInput> Vertices { get; set; }
        public MovingLoad MovingLoads { get; set; }
        public TimeSettings TimeSettings { get; set; }
    }
}