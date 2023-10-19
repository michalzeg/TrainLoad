using StruCal.TrainLoad.App.DTO;

namespace StruCal.TrainLoad.App.DTO.Input
{
    public class VertexInputDTO
    {
        public string BarId { get; set; }
        public string MeshId { get; set; }
        public List<Point3DDTO> Vertices { get; set; }
    }
}