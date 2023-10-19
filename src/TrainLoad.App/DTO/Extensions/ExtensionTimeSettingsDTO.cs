using StruCal.TrainLoad.App.DTO.Input;
using StruCal.TrainLoad.Domain.Input;

namespace StruCal.TrainLoad.App.DTO.Extensions
{
    public static class ExtensionTimeSettingsDTO
    {
        public static TimeSettings ToTimeSettings(this TimeSettingsDTO timeSettingsDTO)
        {
            return new TimeSettings
            {
                DeltaTime = timeSettingsDTO.DeltaTime,
                StartTime = timeSettingsDTO.StartTime,
                EndTime = timeSettingsDTO.EndTime,
                DeltaTimeResults = timeSettingsDTO.DeltaTimeResults,
            };
        }

        public static TimeSettingsDTO ToTimeSettingsDTO(this TimeSettings timeSettings)
        {
            return new TimeSettingsDTO
            {
                DeltaTime = timeSettings.DeltaTime,
                StartTime = timeSettings.StartTime,
                EndTime = timeSettings.EndTime,
                DeltaTimeResults = timeSettings.DeltaTimeResults,
            };
        }
    }
}