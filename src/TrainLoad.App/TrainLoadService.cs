using Microsoft.Extensions.Logging;
using StruCal.TrainLoad.App.DTO;
using StruCal.TrainLoad.App.DTO.Extensions;
using StruCal.TrainLoad.App.DTO.Input;
using StruCal.TrainLoad.App.DTO.Output;
using StruCal.TrainLoad.App.Storage;
using StruCal.TrainLoad.Domain;

namespace StruCal.TrainLoad.App
{

    public class TrainLoadService : ITrainLoadService
    {
        private readonly ILogger<TrainLoadService> _logger;
        private readonly IResultStorage _dataProvider;
        private readonly ITrainLoadCalculator _trainLoadCalculator;

        public TrainLoadService(ILogger<TrainLoadService> logger, IResultStorage dataProvider, ITrainLoadCalculator trainLoadCalculator)
        {
            _logger = logger;
            _dataProvider = dataProvider;
            _trainLoadCalculator = trainLoadCalculator;
        }

        public Guid StartCalculations()
        {
            var operationGuid = _dataProvider.StartOperation();
            _dataProvider.SetProgress(operationGuid, Progress.ReceivingInputData);

            return operationGuid;
        }

        public async Task PerformCalculations(TrainLoadInputDTO input, Guid operationId)
        {
            _dataProvider.SetProgress(operationId, Progress.Calculations);

            var result = await _trainLoadCalculator.Calculate(input.ToTrainLoadInput());
            var resultDto = result.ToTrainLoadOutputDTO();

            _dataProvider.SetResultCollection(operationId, resultDto.Chunk().ToList());
            _dataProvider.SetProgress(operationId, Progress.PreparingResult);
        }

        public TrainLoadOutputDTO GetResult(Guid operationId, int index)
        {
            var result = _dataProvider.GetResultAs(operationId, index);
            _dataProvider.SetProgress(operationId, Progress.SendingResults);

            return result;
        }

        public TrainLoadResultIndexesDto GetResultIndexes(Guid operationId)
        {
            var indexes = _dataProvider.GetResultIndexes(operationId);
            return new TrainLoadResultIndexesDto { Indexes = indexes.ToArray() };
        }

        public TrainLoadProgress GetProgress(Guid operationId)
        {
            var progress = _dataProvider.GetProgress(operationId);
            var hasResult = _dataProvider.HasResult(operationId);

            return new TrainLoadProgress(progress, hasResult);
        }
    }
}