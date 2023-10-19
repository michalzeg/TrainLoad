using StruCal.TrainLoad.App.DTO.Input;
using StruCal.TrainLoad.Domain.Input;

namespace StruCal.TrainLoad.App.DTO.Extensions
{
    public static class ExtensionMovingForceDTO
    {
        public static MovingForce ToMovingForce(this MovingForceDTO movingForceDTO)
        {
            return new MovingForce
            {
                BasePosition = movingForceDTO.BasePosition,
                Load = movingForceDTO.Load,
            };
        }
    }
}