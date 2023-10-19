using System.Collections.Generic;

namespace StruCal.TrainLoad.Domain.Output
{
    public class MeshColorResult
    {
        public string MeshId { get; set; }
        public string BarId { get; set; }
        public IEnumerable<VertexColorResult>? VertexResults { get; set; }
    }
}