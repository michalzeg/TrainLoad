using StruCal.TrainLoad.Domain.Output;

namespace StruCal.TrainLoad.App.DTO.Output
{
    public class MeshColorResultDTO
    {
        public string MeshId { get; set; }
        public string BarId { get; set; }
        public IEnumerable<VertexColorResultDTO> VertexResults { get; set; }
    }

    public static class ExtensionMeshColorResultDTO
    {
        public static MeshColorResultDTO ToMeshColorResultDTO(this MeshColorResult meshColorResult)
        {
            return new MeshColorResultDTO
            {
                BarId = meshColorResult.BarId,
                MeshId = meshColorResult.MeshId,
                VertexResults = meshColorResult.VertexResults.Select(e => e.ToVertexColorResultDTO()).ToList(),
            };
        }
    }
}