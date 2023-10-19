using StruCal.TrainLoad.Domain.Input;

namespace StruCal.TrainLoad.Domain
{
    public interface IFEMCalculatorFacade
    {
        Task<FemResultCalculator> Calculate(TrainLoadInput trainLoadInput);
    }
}