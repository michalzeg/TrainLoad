using Common.Geometry;
using FEM2DDynamics.Elements.Beam;
using FEM2DDynamics.Results.Beam;
using FEM2DStressCalculator.Beams;
using StruCal.TrainLoad.Domain.Output;
using StruCal.TrainLoad.Domain.Utils;
using System.Collections.Generic;
using System.Linq;

namespace StruCal.TrainLoad.Domain
{
    internal class VertexResultCalculator
    {
        private readonly DynamicBeamElementResult _beamResult;
        private readonly IDynamicBeamElement _beam;
        private readonly BeamStressCalculator _stressCalculator;

        public VertexResultCalculator(DynamicBeamElementResult beamResult, IDynamicBeamElement beam, BeamStressCalculator stressCalculator)
        {
            _beamResult = beamResult;
            _beam = beam;
            _stressCalculator = stressCalculator;
        }

        public static VertexResultCalculator FromFEMResult(FemResultCalculator femResults, IDynamicBeamElement beam, double time)
        {
            var stressCalculator = femResults.GetStressCalculator(beam);
            var beamResult = femResults.GetResult(beam, time);
            return new VertexResultCalculator(beamResult, beam, stressCalculator);
        }

        public VertexStressResult GetVertexStressResult(Point3D vertex)
        {
            var location = vertex.ToFEMCoordinateSystem();
            var relativePosition = (location.X - _beam.Nodes[0].Coordinates.X) / _beam.Length;
            var displacement = _beamResult.GetDisplacement(relativePosition);
            var acceleration = _beamResult.GetAcceleration(relativePosition);
            var forces = _beamResult.GetBeamForces(relativePosition);

            var stress = _stressCalculator.NormalStressAt(forces, location.Y);

            var vertexResult = VertexStressResult.GenerateVertexResult(vertex, displacement, stress, acceleration);
            return vertexResult;
        }

        public IEnumerable<VertexStressResult> GetVertexStressResult(IEnumerable<Point3D> vertices)
        {
            return vertices.Select(v => GetVertexStressResult(v));
        }
    }
}