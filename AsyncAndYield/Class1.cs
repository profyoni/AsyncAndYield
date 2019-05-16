using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAndYield
{
    public static class Sequence
    {
        public static IEnumerable<int>  Range(int begin, int end)
        {
            for (int i = begin; i < end; i++)
            {
                yield return i;
            }
        }
    }

    public static class AsyncLib
    {
        public static int SlowRandom()
        {
            Thread.Sleep(10000);
            return new Random().Next();
        }
        public static async Task<int> SlowRandomAsync()
        {
            int result = await Task.Run(() => SlowRandom());
            return result;
        }
    }


}
