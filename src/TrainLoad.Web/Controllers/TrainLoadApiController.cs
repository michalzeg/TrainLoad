using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Quartz;
using StruCal.TrainLoad;
using StruCal.TrainLoad.App;
using StruCal.TrainLoad.App.DTO.Input;

namespace StruCal.TrailLoad.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrainLoadApiController : ControllerBase
    {
        private readonly ITrainLoadService _trainLoadService;
        private readonly ISchedulerFactory _factory;

        public TrainLoadApiController(ITrainLoadService trainLoadService, ISchedulerFactory factory)
        {
            _trainLoadService = trainLoadService;
            _factory = factory;
        }

        [HttpPost]
        public async Task<IActionResult> StartCalculations(TrainLoadInputDTO input)
        {
            var operationGuid = _trainLoadService.StartCalculations();
            await RedirectToCalculations(input, operationGuid);
            return Ok(operationGuid);
        }

        [HttpGet]
        [Route("{operationId}/Result/{index}")]
        public IActionResult GetResult(Guid operationId, int index)
        {
            var result = _trainLoadService.GetResult(operationId, index);
            return Ok(result);
        }

        [HttpGet]
        [Route("{operationId}/Result/Indexes")]
        public IActionResult GetResultIndexes(Guid operationId)
        {
            var result = _trainLoadService.GetResultIndexes(operationId);
            return Ok(result);
        }

        [HttpGet]
        [Route("{operationId}/Progress")]
        public IActionResult GetProgress(Guid operationId)
        {
            var result = _trainLoadService.GetProgress(operationId);
            return Ok(result);
        }

        public async Task RedirectToCalculations(TrainLoadInputDTO inputDTO, Guid operationId)
        {
            var job = JobBuilder.Create<CalculationJob>()
                        .WithIdentity(operationId.ToString(), "calculations")
                        .UsingJobData(CalculationJob.InputKey, JsonConvert.SerializeObject(inputDTO))
                        .UsingJobData(CalculationJob.OperationIdKey,operationId)
                        .Build();

            var trigger = TriggerBuilder.Create()
                .WithIdentity(operationId.ToString(), "calculations")
                .WithSimpleSchedule()
                .StartNow()
                .Build();
            var scheduler = await _factory.GetScheduler();
            await scheduler.ScheduleJob(job, trigger);
        }
    }
}