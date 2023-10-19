using Common.Geometry;

namespace StruCal.TrainLoad.App.DTO.Extensions
{
    public static class ExtensionPoint3DDTO
    {
        public static Point3D ToPointD(this Point3DDTO point)
        {
            return new Point3D(point.X, point.Y, point.Z);
        }

        public static Point3DDTO ToPointDDTO(this Point3D point)
        {
            return new Point3DDTO
            {
                X = point.X,
                Y = point.Y,
                Z = point.Z,
            };
        }
    }
}