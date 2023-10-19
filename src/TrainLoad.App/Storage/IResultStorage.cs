using StruCal.TrainLoad.App.DTO.Output;
using System;
using System.Collections.Generic;

namespace StruCal.TrainLoad.App.Storage
{
    public interface IResultStorage
    {
        Progress GetProgress(Guid operationId);

        TrainLoadOutputDTO GetResultAs(Guid operationId, int index);

        void SetProgress(Guid operationId, Progress progress);

        void SetResultCollection(Guid operationId, IList<TrainLoadOutputDTO> results);

        Guid StartOperation();

        bool HasResult(Guid operationId);

        IEnumerable<int> GetResultIndexes(Guid operationId);
    }
}