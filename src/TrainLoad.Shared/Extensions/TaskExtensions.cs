using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace StruCal.TrainLoad.Shared.Extensions
{
    public static class TaskExtensions
    {
        public static Task<TResult>[] ToTask<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> func)
        {
            return source.Select(e => Task.Run(() => func(e))).ToArray();
        }

        public static IList<TResult> WaitAll<TResult>(this IEnumerable<Task<TResult>> source)
        {
            Task.WaitAll(source.ToArray());
            return source.Select(e => e.Result).ToList();
        }

        public static async Task<IList<TResult>> WhenAll<TResult>(this IEnumerable<Task<TResult>> source)
        {
            await Task.WhenAll(source.ToArray());
            return source.Select(e => e.Result).ToList();
        }
    }
}