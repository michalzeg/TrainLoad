using Common.Geometry;
using System.Collections.Generic;

namespace StruCal.TrainLoad.Domain.Input
{
    public class VertexInput
    {
        public string BarId { get; set; }
        public string MeshId { get; set; }
        public IReadOnlyCollection<Point3D> Vertices { get; set; }
    }
}