namespace StruCal.TrainLoad.App.Storage
{
    public class MemoryStorageContainer<T>
    {
        public Guid OperationId { get; }
        public DateTime CreatedAt { get; }
        public Progress CurrentProgress { get; set; }

        private readonly Dictionary<int, T> _results = new Dictionary<int, T>();

        public MemoryStorageContainer(Guid operationId)
        {
            OperationId = operationId;
            CreatedAt = DateTime.Now;
        }

        public bool HasResult() => _results.Any();

        public IReadOnlyCollection<int> GetIndexes() => _results.Keys.Select((e, i) => i).ToList();

        public void AddResult(int index, T data)
        {
            _results.Add(index, data);
        }

        public T GetResult(int index)
        {
            _results.Remove(index, out var result);
            return result;
        }
    }
}