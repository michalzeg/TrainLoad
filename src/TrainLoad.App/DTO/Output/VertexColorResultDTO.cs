using StruCal.TrainLoad.App.DTO.Extensions;
using StruCal.TrainLoad.Domain.Output;

namespace StruCal.TrainLoad.App.DTO.Output
{
    public class VertexColorResultDTO
    {
        public Point3DDTO Position { get; set; }
        public double Displacement { get; set; }

        public string Color { get; set; }
    }

    public static class ExtensionVertexColorResultDTO
    {
        public static VertexColorResultDTO ToVertexColorResultDTO(this VertexColorResult vertexColorResult)
        {
            return new VertexColorResultDTO
            {
                Color = vertexColorResult.Color,
                Displacement = vertexColorResult.Displacement,
                Position = vertexColorResult.Position.ToPointDDTO(),
            };
        }
    }
}