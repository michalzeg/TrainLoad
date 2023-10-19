using StruCal.TrainLoad.App.DTO.Input;
using StruCal.TrainLoad.Domain.Input;

namespace StruCal.TrainLoad.App.DTO.Extensions
{
    public static class ExtensionVertexInputDTO
    {
        public static VertexInput ToVertexInput(this VertexInputDTO vertexInputDTO)
        {
            return new VertexInput
            {
                BarId = vertexInputDTO.BarId,
                MeshId = vertexInputDTO.MeshId,
                Vertices = vertexInputDTO.Vertices.Select(e => e.ToPointD()).ToList(),
            };
        }
    }
}