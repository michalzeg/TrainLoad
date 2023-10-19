using Common.Geometry;
using StruCal.TrainLoad.Domain.GradientColor;

namespace StruCal.TrainLoad.Domain.Output
{
    public class VertexStressResult
    {
        public Point3D? Position { get; private set; }
        public double Displacement { get; private set; }
        public double Acceleration { get; private set; }
        public double Stress { get; private set; }

        public static VertexStressResult GenerateVertexResult(Point3D vertex, double displacement, double stress, double acceleration)
        {
            return new VertexStressResult
            {
                Position = vertex,
                Stress = stress,
                Displacement = displacement,
                Acceleration = acceleration,
            };
        }

        public VertexColorResult ConvertToColor(IColorCalculator colorCalculator)
        {
            var result = new VertexColorResult
            {
                Displacement = Displacement,
                Position = Position,
                Color = colorCalculator.GetColor(Stress)
            };
            return result;
        }
    }
}