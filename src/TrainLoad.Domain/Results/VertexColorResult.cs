using Common.Geometry;

namespace StruCal.TrainLoad.Domain.Output
{
    public class VertexColorResult
    {
        public Point3D? Position { get; set; }
        public double Displacement { get; set; }

        public string? Color { get; set; }
    }
}