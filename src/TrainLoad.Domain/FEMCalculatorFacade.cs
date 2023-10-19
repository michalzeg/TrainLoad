using Common.Geometry;
using FEM2DCommon.ElementProperties.Builder;
using FEM2DDynamics.Elements.Beam;
using FEM2DDynamics.Structure;
using StruCal.TrainLoad.Domain.Extensions;
using StruCal.TrainLoad.Domain.Input;
using StruCal.TrainLoad.Domain.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;
using FEMSection = FEM2DCommon.Sections.Section;

namespace StruCal.TrainLoad.Domain
{
    public class FEMCalculatorFacade : IFEMCalculatorFacade
    {
        private const double dampingRatio = 0.03;

        private TrainLoadInput _trainLoadInput;
        private DynamicStructure _structure;
        private readonly Dictionary<IDynamicBeamElement, string> _elementBarIdMap = new();


        public async Task<FemResultCalculator> Calculate(TrainLoadInput trainLoadInput)
        {
            _trainLoadInput = trainLoadInput;
            var settings = _trainLoadInput.TimeSettings.ToDynamicSolverSettings(dampingRatio);
            _structure = new DynamicStructure(settings);

            GenerateNodesAndElements();
            GenerateSupports();
            GenerateMovingLoads();

            await _structure.Solve();

            var results = _structure.Results.BeamResults;
            return FemResultCalculator.Create(_elementBarIdMap, results);
        }

        private void GenerateMovingLoads()
        {
            var speed = _trainLoadInput.MovingLoads.Speed;
            foreach (var movingLoad in _trainLoadInput.MovingLoads.Forces)
            {
                _structure.LoadFactory.AddPointMovingLoad(movingLoad.Load, movingLoad.BasePosition, speed);
            }
        }

        private void GenerateSupports()
        {
            foreach (var support in _trainLoadInput.StructureGeometry.Supports)
            {
                var restraint = RestraintConverter.ConvertFromString(support.Direction);
                var location = support.Location.ToFEMCoordinateSystem();
                _structure.NodeFactory.SetSupportAt(location, restraint);
            }
        }

        private void GenerateNodesAndElements()
        {
            foreach (var bar in _trainLoadInput.StructureGeometry.Bars)
            {
                var section = new FEMSection(bar.Section.Perimeters.Convert());

                var dynamicProperties = DynamicBeamPropertiesBuilder.Create()
                    .SetSteel()
                    .SetSection(section)
                    .Build();

                var startPoint = new PointD(bar.StartPoint.Z, bar.StartPoint.Y);
                var endPoint = new PointD(bar.EndPoint.Z, bar.EndPoint.Y);
                var startNode = _structure.NodeFactory.Create(startPoint);
                var endNode = _structure.NodeFactory.Create(endPoint);
                var element = _structure.ElementFactory.CreateBeam(startNode, endNode, dynamicProperties);

                _elementBarIdMap.Add(element, bar.Id);
            }
        }
    }
}