using StruCal.TrainLoad.App.DTO.Input;
using StruCal.TrainLoad.Domain.Input;

namespace StruCal.TrainLoad.App.DTO.Extensions
{
    public static class ExtensionPerimeterDTO
    {
        public static Perimeter ToPerimeter(this PerimeterDTO perimeterDTO)
        {
            return new Perimeter
            {
                Coordinates = perimeterDTO.Coordinates.Select(e => e.ToPointD()).ToList(),
            };
        }
    }
}