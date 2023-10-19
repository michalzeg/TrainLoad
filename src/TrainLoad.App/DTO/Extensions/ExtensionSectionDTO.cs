using StruCal.TrainLoad.App.DTO.Input;
using StruCal.TrainLoad.Domain.Input;

namespace StruCal.TrainLoad.App.DTO.Extensions
{
    public static class ExtensionSectionDTO
    {
        public static Section ToSection(this SectionDTO sectionDTO)
        {
            return new Section
            {
                Perimeters = sectionDTO.Perimeters.Select(e => e.ToPerimeter()).ToList(),
            };
        }
    }
}