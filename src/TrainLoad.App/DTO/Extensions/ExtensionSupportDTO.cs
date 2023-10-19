using StruCal.TrainLoad.App.DTO.Input;
using StruCal.TrainLoad.Domain.Input;

namespace StruCal.TrainLoad.App.DTO.Extensions
{
    public static class ExtensionSupportDTO
    {
        public static Support ToSupport(this SupportDTO supportDTO)
        {
            return new Support
            {
                Direction = supportDTO.Direction,
                Location = supportDTO.Location.ToPointD(),
            };
        }
    }
}