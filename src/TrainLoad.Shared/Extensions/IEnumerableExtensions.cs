using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StruCal.TrainLoad.Shared.Extensions
{
    public static class IEnumerableExtensions
    {
        public static void AddRange<T>(this IList<T> list, IEnumerable<T> items)
        {
            if (list == null) throw new ArgumentNullException(nameof(list));
            if (items == null) throw new ArgumentNullException(nameof(items));

            if (list is List<T> asList)
            {
                asList.AddRange(items);
            }
            else
            {
                foreach (var item in items)
                {
                    list.Add(item);
                }
            }
        }

        public static List<List<T>> ChunkOnParts<T>(this IEnumerable<T> source, int parts)
        {
            var chunkSize = (int)Math.Ceiling(source.Count() / (parts * 1d));

            return source.ChunkBySize(chunkSize);
        }

        public static List<List<T>> ChunkBySize<T>(this IEnumerable<T> source, int chunkSize)
        {
            return source
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / chunkSize)
                .Select(x => x.Select(v => v.Value).ToList()).ToList();
        }
    }
}