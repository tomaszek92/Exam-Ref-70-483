using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ManageProgramFlow
{
    static class Program
    {
        private static readonly ThreadLocal<int> Field =
            new ThreadLocal<int>(() => Thread.CurrentThread.ManagedThreadId);

        private static void Main(string[] args)
        {
            //Task<int> t = Task.Run(() => 42);
            //t.ContinueWith(i => { Console.WriteLine("ContinueWith"); });
            //t.ContinueWith(i => { Console.WriteLine("Canceled"); }, TaskContinuationOptions.OnlyOnCanceled);
            //t.ContinueWith(i => { Console.WriteLine("Faulted"); }, TaskContinuationOptions.OnlyOnFaulted);
            //t.ContinueWith(i => { Console.WriteLine("Completed"); }, TaskContinuationOptions.OnlyOnRanToCompletion);
            //t.Wait();
            //Console.ReadKey();

            var enumerable = Enumerable.Range(0, 1000);
            ParallelLoopResult result = Parallel.ForEach(enumerable, (int i, ParallelLoopState loopState) =>
            {
                if (i == 500)
                {
                    loopState.Break();
                }
                return;
            });
        }

        private static void ThreadProc(object stateInfo)
        {
            // No state object was passed to QueueUserWorkItem, so stateInfo is null.
            Console.WriteLine("Hello from the thread pool.");
        }
    }
}