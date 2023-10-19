using FEM2DDynamics.Elements.Beam;
using StruCal.TrainLoad.Domain.GradientColor;
using StruCal.TrainLoad.Domain.Input;
using StruCal.TrainLoad.Domain.Output;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StruCal.TrainLoad.Domain
{
    public class TrainLoadResultCreator : ITrainLoadResultCreator
    {
        private const double NormalizationFactor = 0.9;
        private readonly IColorCalculatorFactory _colorCalculatorFactory;

        public TrainLoadResultCreator(IColorCalculatorFactory colorCalculatorFactory)
        {
            _colorCalculatorFactory = colorCalculatorFactory;
        }

        public TrainLoadResult Calculate(FemResultCalculator femResults, TrainLoadInput trainLoadInput)
        {
            var beamVerticesMap = GetBeamVerticesMap(femResults, trainLoadInput.Vertices);
            var times = trainLoadInput.TimeSettings.GetTimeRange().ToArray();
            var timeResults = new List<TimeResult>(times.Length);

            foreach (var time in times)
            {
                var meshStressResults = new List<MeshStressResult>();
                foreach (var beam in femResults.GetBeams())
                {
                    var vertexResultCalculator = VertexResultCalculator.FromFEMResult(femResults, beam, time);

                    var beamVertices = beamVerticesMap[beam];
                    var vertexMeshRestresResults = GenerateMeshStressResult(beamVertices, vertexResultCalculator);
                    meshStressResults.AddRange(vertexMeshRestresResults);
                }

                var stresses = GetStresses(meshStressResults);

                var maxStress = stresses.Max();
                var minStress = stresses.Min();

                var maxStressNormalized = stresses.Where(e => e <= NormalizationFactor * maxStress).Max();
                var minStressNormalized = stresses.Where(e => e >= NormalizationFactor * minStress).Min();

                var meshColorResults = ConvertStressToColor(meshStressResults, maxStressNormalized, minStressNormalized);
                var maxAcceleration = GetMaxAcceleration(meshStressResults);

                var timeResult = TimeResult.GenerateTimeResult(time, maxAcceleration, meshColorResults);
                timeResults.Add(timeResult);
            }
            var resultData = new TrainLoadResult
            {
                TimeResults = timeResults,
                MaxAbsoluteDisplacement = GetMaxDisplacement(timeResults),
                TimeSettings = trainLoadInput.TimeSettings
            };
            return resultData;
        }

        private Dictionary<IDynamicBeamElement, List<VertexInput>> GetBeamVerticesMap(FemResultCalculator femResults, IReadOnlyCollection<VertexInput> vertices)
        {
            var result = femResults.GetBeams()
                .ToDictionary(e => e, f => vertices.Where(g => g.BarId == femResults.GetBarId(f)).ToList());
            return result;
        }

        private static IReadOnlyCollection<MeshStressResult> GenerateMeshStressResult(IEnumerable<VertexInput> beamVertices, VertexResultCalculator vertexResultCalculator)
        {
            var result = new List<MeshStressResult>();
            foreach (var beamVertex in beamVertices)
            {
                var vertexResults = vertexResultCalculator.GetVertexStressResult(beamVertex.Vertices).ToList();
                var meshResult = MeshStressResult.GenerateMeshResult(beamVertex, vertexResults);
                result.Add(meshResult);
            }
            return result;
        }

        private static IReadOnlyCollection<double> GetStresses(IEnumerable<MeshStressResult> meshStressResults)
        {
            return meshStressResults
                            .Select(e => e.VertexResults)
                            .SelectMany(e => e!)
                            .Select(e => e.Stress)
                            .ToList();
        }

        private static double GetMaxAcceleration(IEnumerable<MeshStressResult> meshStressResults)
        {
            return meshStressResults.Select(e => e.VertexResults)
                            .SelectMany(e => e!)
                            .Select(e => e.Acceleration)
                            .Max();
        }

        private static double GetMaxDisplacement(IReadOnlyCollection<TimeResult> timeResults)
        {
            var result = timeResults.SelectMany(e => e.MeshResults)
                            .SelectMany(e => e.VertexResults)
                            .Select(e => Math.Abs(e.Displacement))
                            .ToList()
                            .Max();
            return result;
        }

        private IReadOnlyCollection<MeshColorResult> ConvertStressToColor(IEnumerable<MeshStressResult> meshStressResults, double maxStress, double minStress)
        {
            var colorCalculator = _colorCalculatorFactory.GetColorCalculator(maxStress, minStress);
            return meshStressResults.Select(e => e.ConvertToColor(colorCalculator)).ToList();
        }
    }
}