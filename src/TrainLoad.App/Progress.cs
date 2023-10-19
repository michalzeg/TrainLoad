using StruCal.TrainLoad.App.DTO.Output;

namespace StruCal.TrainLoad.App
{
    public enum Progress
    {
        None = 0,
        ReceivingInputData = 1,
        Calculations = 2,
        PreparingResult = 3,
        SendingResults = 4
    }
}