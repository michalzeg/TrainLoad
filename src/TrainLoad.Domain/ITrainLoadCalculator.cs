using StruCal.TrainLoad.Domain.Input;
using StruCal.TrainLoad.Domain.Output;

namespace StruCal.TrainLoad.Domain
{
    public interface ITrainLoadCalculator
    {
        Task<TrainLoadResult> Calculate(TrainLoadInput trainLoadInput);
    }
}