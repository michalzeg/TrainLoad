using FEM2DDynamics.Elements.Beam;
using FEM2DDynamics.Results;
using FEM2DDynamics.Results.Beam;
using FEM2DStressCalculator.Beams;
using System.Collections.Generic;
using System.Linq;

namespace StruCal.TrainLoad.Domain
{
    public class FemResultCalculator
    {
        private readonly DynamicBeamElementResults _beamResults;
        private IDictionary<IDynamicBeamElement, string> _beamElementBarIDMap;
        private readonly IDictionary<IDynamicBeamElement, BeamStressCalculator> _beamStressCalculatorMap;

        public FemResultCalculator(DynamicBeamElementResults beamResults, IDictionary<IDynamicBeamElement, BeamStressCalculator> beamStressCalculatorMap, IDictionary<IDynamicBeamElement, string> beamElementBarIDMap)
        {
            _beamResults = beamResults ?? throw new ArgumentNullException(nameof(beamResults));
            _beamStressCalculatorMap = beamStressCalculatorMap ?? throw new ArgumentNullException(nameof(beamStressCalculatorMap));
            _beamElementBarIDMap = beamElementBarIDMap ?? throw new ArgumentNullException(nameof(beamElementBarIDMap));
        }

        public static FemResultCalculator Create(IDictionary<IDynamicBeamElement, string> beamElementBarIDMap, DynamicBeamElementResults beamResults)
        {
            var beamStressCalculatorMap = beamElementBarIDMap
                .Select(e => e.Key)
                .ToDictionary(f => f, e => new BeamStressCalculator(e.BarProperties.SectionProperties));
            return new FemResultCalculator(beamResults, beamStressCalculatorMap, beamElementBarIDMap);
        }

        public BeamStressCalculator GetStressCalculator(IDynamicBeamElement beam) => _beamStressCalculatorMap[beam];

        public IEnumerable<IDynamicBeamElement> GetBeams() => _beamStressCalculatorMap.Select(e => e.Key);

        public DynamicBeamElementResult GetResult(IDynamicBeamElement beam, double time) => _beamResults.GetResult(beam, time);

        public string GetBarId(IDynamicBeamElement element) => _beamElementBarIDMap[element];
    }
}