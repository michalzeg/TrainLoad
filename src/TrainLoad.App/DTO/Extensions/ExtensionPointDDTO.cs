using Common.Geometry;

namespace StruCal.TrainLoad.App.DTO.Extensions
{
    public static class ExtensionPointDDTO
    {
        public static PointD ToPointD(this PointDDTO point)
        {
            return new PointD(point.X, point.Y);
        }

        public static PointDDTO ToPointDDTO(this PointD point)
        {
            return new PointDDTO
            {
                X = point.X,
                Y = point.Y,
            };
        }
    }
}