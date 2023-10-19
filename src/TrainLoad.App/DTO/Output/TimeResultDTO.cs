using StruCal.TrainLoad.Domain.Output;

namespace StruCal.TrainLoad.App.DTO.Output
{
    public class TimeResultDTO
    {
        public double Acceleration { get; set; }
        public double Time { get; set; }
        public IEnumerable<MeshColorResultDTO> MeshResults { get; set; }
    }

    public static class ExtensionTimeResultDTO
    {
        public static TimeResultDTO ToTimeResultDTO(this TimeResult timeResult)
        {
            return new TimeResultDTO
            {
                MeshResults = timeResult.MeshResults.Select(e => e.ToMeshColorResultDTO()).ToList(),
                Time = timeResult.Time,
                Acceleration = timeResult.Acceleration,
            };
        }
    }
}