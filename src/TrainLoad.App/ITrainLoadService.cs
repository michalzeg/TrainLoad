using StruCal.TrainLoad.App.DTO;
using StruCal.TrainLoad.App.DTO.Input;
using StruCal.TrainLoad.App.DTO.Output;

namespace StruCal.TrainLoad.App
{
    public interface ITrainLoadService
    {
        TrainLoadProgress GetProgress(Guid operationId);
        TrainLoadOutputDTO GetResult(Guid operationId, int index);
        TrainLoadResultIndexesDto GetResultIndexes(Guid operationId);
        Task PerformCalculations(TrainLoadInputDTO input, Guid operationId);
        Guid StartCalculations();
    }
}