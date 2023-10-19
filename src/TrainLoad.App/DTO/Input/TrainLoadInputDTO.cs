namespace StruCal.TrainLoad.App.DTO.Input
{
    public class TrainLoadInputDTO
    {
        public StructureGeometryDTO StructureGeometry { get; set; }
        public List<VertexInputDTO> Vertices { get; set; }
        public MovingLoadDTO MovingLoads { get; set; }
        public TimeSettingsDTO TimeSettings { get; set; }
    }
}