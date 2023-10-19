using StruCal.TrainLoad.App.DTO.Input;
using StruCal.TrainLoad.Domain.Input;

namespace StruCal.TrainLoad.App.DTO.Extensions
{
    public static class ExtensionMovingLoadDTO
    {
        public static MovingLoad ToMovingLoad(this MovingLoadDTO movingLoadDTO)
        {
            return new MovingLoad
            {
                Speed = movingLoadDTO.Speed,
                Forces = movingLoadDTO.Forces.Select(e => e.ToMovingForce()).ToList()
            };
        }
    }
}