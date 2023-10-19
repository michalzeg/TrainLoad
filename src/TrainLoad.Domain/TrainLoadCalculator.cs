using Microsoft.Extensions.Logging;
using StruCal.TrainLoad.Domain.GradientColor;
using StruCal.TrainLoad.Domain.Input;
using StruCal.TrainLoad.Domain.Output;

namespace StruCal.TrainLoad.Domain
{
    public class TrainLoadCalculator : ITrainLoadCalculator
    {
        private readonly ILogger<TrainLoadCalculator> _logger;
        private readonly ITrainLoadResultCreator _resultCreator;
        private readonly IFEMCalculatorFacade _femCalculator;

        public TrainLoadCalculator(ILogger<TrainLoadCalculator> logger, ITrainLoadResultCreator resultCreator, IFEMCalculatorFacade femCalculator)
        {
            _logger = logger;
            _resultCreator = resultCreator;
            _femCalculator = femCalculator;
        }

        public async Task<TrainLoadResult> Calculate(TrainLoadInput trainLoadInput)
        {
            try
            {
                var femResult = await _femCalculator.Calculate(trainLoadInput);
                var output = _resultCreator.Calculate(femResult, trainLoadInput);
                return output;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Problem with calculations");
                throw;
            }
        }
    }
}