using System;
using System.Threading.Tasks;

namespace ManageProgramFlow
{
    public class TaskExamples
    {
        public void ContinueWith()
        {
            Task<int> t = Task.Run(() => 42);
            t.ContinueWith(i => { Console.WriteLine("ContinueWith"); });
            t.ContinueWith(i => { Console.WriteLine("Canceled"); }, TaskContinuationOptions.OnlyOnCanceled);
            t.ContinueWith(i => { Console.WriteLine("Faulted"); }, TaskContinuationOptions.OnlyOnFaulted);
            t.ContinueWith(i => { Console.WriteLine("Completed"); }, TaskContinuationOptions.OnlyOnRanToCompletion);
            t.Wait();
        }
    }
}