using StruCal.TrainLoad.App.DTO;

namespace StruCal.TrainLoad.App.DTO.Input
{
    public class BarDTO
    {
        public string Id { get; set; }
        public Point3DDTO StartPoint { get; set; }
        public Point3DDTO EndPoint { get; set; }
        public SectionDTO Section { get; set; }
    }
}