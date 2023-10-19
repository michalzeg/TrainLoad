using Newtonsoft.Json;
using Quartz;
using StruCal.TrainLoad.App;
using StruCal.TrainLoad.App.DTO.Input;
using System;
using System.Threading.Tasks;

namespace StruCal.TrainLoad
{
    public class CalculationJob : IJob
    {
        public const string OperationIdKey = "operationId";
        public const string InputKey = "input";
        private readonly TrainLoadService _trainLoadService;

        public CalculationJob(TrainLoadService trainLoadService)
        {
            _trainLoadService = trainLoadService;
        }
        public async Task Execute(IJobExecutionContext context)
        {

            JobDataMap dataMap = context.JobDetail.JobDataMap;
            var input = JsonConvert.DeserializeObject<TrainLoadInputDTO>( dataMap.GetString(InputKey));
            var operationId = dataMap.GetGuid(OperationIdKey);

            await _trainLoadService.PerformCalculations(input, operationId);

        }
    }
}
