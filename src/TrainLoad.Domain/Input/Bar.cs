using Common.Geometry;

namespace StruCal.TrainLoad.Domain.Input
{
    public class Bar
    {
        public string Id { get; set; }
        public Point3D StartPoint { get; set; }
        public Point3D EndPoint { get; set; }
        public Section Section { get; set; }
    }
}