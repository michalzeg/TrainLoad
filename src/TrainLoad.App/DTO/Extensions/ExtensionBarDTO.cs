using StruCal.TrainLoad.App.DTO.Input;
using StruCal.TrainLoad.Domain.Input;

namespace StruCal.TrainLoad.App.DTO.Extensions
{
    public static class ExtensionBarDTO
    {
        public static Bar ToBar(this BarDTO barDTO)
        {
            return new Bar
            {
                Id = barDTO.Id,
                StartPoint = barDTO.StartPoint.ToPointD(),
                EndPoint = barDTO.EndPoint.ToPointD(),
                Section = barDTO.Section.ToSection(),
            };
        }
    }
}