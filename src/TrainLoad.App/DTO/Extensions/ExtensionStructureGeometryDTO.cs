using StruCal.TrainLoad.App.DTO.Input;
using StruCal.TrainLoad.Domain.Input;
namespace StruCal.TrainLoad.App.DTO.Extensions
{
    public static class ExtensionStructureGeometryDTO
    {
        public static StructureGeometry ToStructureGeometry(this StructureGeometryDTO structureGeometryDTO)
        {
            return new StructureGeometry
            {
                Bars = structureGeometryDTO.Bars.Select(e => e.ToBar()).ToList(),
                Supports = structureGeometryDTO.Supports.Select(e => e.ToSupport()).ToList()
            };
        }
    }
}