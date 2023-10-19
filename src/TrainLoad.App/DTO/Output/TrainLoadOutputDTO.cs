using Newtonsoft.Json;
using StruCal.TrainLoad.App.DTO.Extensions;
using StruCal.TrainLoad.App.DTO.Input;
using StruCal.TrainLoad.Domain.Output;
using StruCal.TrainLoad.Shared.Extensions;

namespace StruCal.TrainLoad.App.DTO.Output
{
    public class TrainLoadOutputDTO
    {
        public const int ChunkCount = 20;

        public double MaxAbsoluteDisplacement { get; set; }
        public IEnumerable<TimeResultDTO> TimeResults { get; set; }
        public TimeSettingsDTO TimeSettings { get; set; }

        public IEnumerable<TrainLoadOutputDTO> Chunk() => TimeResults.ChunkOnParts(ChunkCount).Select(e => new TrainLoadOutputDTO
        {
            MaxAbsoluteDisplacement = MaxAbsoluteDisplacement,
            TimeSettings = TimeSettings,
            TimeResults = e
        });

    }

    public static class ExtensionTrainLoadOutputDTO
    {
        public static TrainLoadOutputDTO ToTrainLoadOutputDTO(this TrainLoadResult trainLoadOutput)
        {
            return new TrainLoadOutputDTO
            {
                MaxAbsoluteDisplacement = trainLoadOutput.MaxAbsoluteDisplacement,
                TimeResults = trainLoadOutput.TimeResults.Select(e => e.ToTimeResultDTO()).ToList(),
                TimeSettings = trainLoadOutput.TimeSettings.ToTimeSettingsDTO(),
            };
        }
    }
}