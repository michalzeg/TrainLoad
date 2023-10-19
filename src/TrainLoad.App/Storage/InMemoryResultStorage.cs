using StruCal.TrainLoad.App.DTO.Output;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace StruCal.TrainLoad.App.Storage
{
    public class MemoryDataProvider : IResultStorage
    {
        private readonly ConcurrentDictionary<Guid, MemoryStorageContainer<TrainLoadOutputDTO>> _buffer = new();

        public Progress GetProgress(Guid operationId)
        {
            return _buffer[operationId].CurrentProgress;
        }

        public TrainLoadOutputDTO GetResultAs(Guid operationId, int index)
        {
            var storage = _buffer.GetOrAdd(operationId, new MemoryStorageContainer<TrainLoadOutputDTO>(operationId));
            return storage.GetResult(index);
        }

        public IEnumerable<int> GetResultIndexes(Guid operationId)
        {
            var storage = _buffer.GetOrAdd(operationId, new MemoryStorageContainer<TrainLoadOutputDTO>(operationId));

            return storage.GetIndexes();
        }

        public bool HasResult(Guid operationId)
        {
            var storage = _buffer.GetOrAdd(operationId, new MemoryStorageContainer<TrainLoadOutputDTO>(operationId));
            return storage.HasResult();
        }

        public void SetProgress(Guid operationId, Progress progress)
        {
            var storage = _buffer.GetOrAdd(operationId, new MemoryStorageContainer<TrainLoadOutputDTO>(operationId));

            storage.CurrentProgress = progress;
        }

        public void SetResultCollection(Guid operationId, IList<TrainLoadOutputDTO> results)
        {
            var storage = _buffer.GetOrAdd(operationId, new MemoryStorageContainer<TrainLoadOutputDTO>(operationId));
            foreach (var (item, index) in results.Select((item, index) => (item, index)))
            {
                storage.AddResult(index, item);
            }
        }

        public Guid StartOperation()
        {
            var operationId = Guid.NewGuid();
            var storage = _buffer.GetOrAdd(operationId, new MemoryStorageContainer<TrainLoadOutputDTO>(operationId));
            return operationId;
        }
    }
}