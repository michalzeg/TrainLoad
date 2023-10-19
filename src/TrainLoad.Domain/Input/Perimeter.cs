using Common.Geometry;
using System.Collections.Generic;

namespace StruCal.TrainLoad.Domain.Input
{
    public class Perimeter
    {
        public IReadOnlyCollection<PointD> Coordinates { get; set; }
    }
}