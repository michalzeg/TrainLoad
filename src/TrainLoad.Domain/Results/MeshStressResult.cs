using StruCal.TrainLoad.Domain.GradientColor;
using StruCal.TrainLoad.Domain.Input;
using System.Collections.Generic;
using System.Linq;

namespace StruCal.TrainLoad.Domain.Output
{
    public class MeshStressResult
    {
        public string? MeshId { get; private set; }
        public string? BarId { get; private set; }
        public IEnumerable<VertexStressResult>? VertexResults { get; private set; }

        public static MeshStressResult GenerateMeshResult(VertexInput beamVertex, List<VertexStressResult> vertexResults)
        {
            return new MeshStressResult
            {
                BarId = beamVertex.BarId,
                MeshId = beamVertex.MeshId,
                VertexResults = vertexResults,
            };
        }

        public MeshColorResult ConvertToColor(IColorCalculator colorCalculator)
        {
            var result = new MeshColorResult();
            result.BarId = BarId;
            result.MeshId = MeshId;
            result.VertexResults = VertexResults?.Select(f => f.ConvertToColor(colorCalculator));
            return result;
        }
    }
}