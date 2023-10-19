using Common.Geometry;

namespace StruCal.TrainLoad.Domain.Utils
{
    internal static class PointDUtils
    {
        public static PointD ToFEMCoordinateSystem(this Point3D point)
        {
            return new PointD(point.Z, point.Y);
        }
    }
}