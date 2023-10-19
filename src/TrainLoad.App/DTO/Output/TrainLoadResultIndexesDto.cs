using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StruCal.TrainLoad.App.DTO.Output
{
    public record TrainLoadResultIndexesDto
    {
        public IReadOnlyCollection<int> Indexes { get; init; }
    }
}