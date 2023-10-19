using System.Linq;
namespace StruCal.TrainLoad.App.DTO.Input
{
    public class StructureGeometryDTO
    {
        public List<BarDTO> Bars { get; set; }
        public List<SupportDTO> Supports { get; set; }
    }
}