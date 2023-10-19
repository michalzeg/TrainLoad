using StruCal.TrainLoad.App.DTO.Input;
using StruCal.TrainLoad.Domain.Input;

namespace StruCal.TrainLoad.App.DTO.Extensions
{
    public static class ExtensionTrainLoadInputDTO
    {
        public static TrainLoadInput ToTrainLoadInput(this TrainLoadInputDTO trainLoadInputDTO)
        {
            return new TrainLoadInput
            {
                StructureGeometry = trainLoadInputDTO.StructureGeometry.ToStructureGeometry(),
                Vertices = trainLoadInputDTO.Vertices.Select(e => e.ToVertexInput()).ToList(),
                MovingLoads = trainLoadInputDTO.MovingLoads.ToMovingLoad(),
                TimeSettings = trainLoadInputDTO.TimeSettings.ToTimeSettings(),
            };
        }
    }
}