namespace StruCal.TrainLoad.App.DTO.Input
{
    public class MovingLoadDTO
    {
        public double Speed { get; set; }
        public List<MovingForceDTO> Forces { get; set; }
    }
}