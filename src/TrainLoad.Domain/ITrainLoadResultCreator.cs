using StruCal.TrainLoad.Domain.Input;
using StruCal.TrainLoad.Domain.Output;

namespace StruCal.TrainLoad.Domain
{
    public interface ITrainLoadResultCreator
    {
        TrainLoadResult Calculate(FemResultCalculator femResults, TrainLoadInput trainLoadInput);
    }
}