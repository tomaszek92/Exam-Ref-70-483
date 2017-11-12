using System;
using System.Threading;
using System.Threading.Tasks;

namespace ManageProgramFlow
{
    public class CancellingTasksExamples
    {
        public static void CancellTask()
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationToken cancellationToken = cancellationTokenSource.Token;
            Task task = Task.Run(() =>
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    Console.WriteLine("Sleeping for 1 second");
                    Thread.Sleep(1000);
                }
            }, cancellationToken);

            Console.ReadLine();
            cancellationTokenSource.Cancel();
            Console.WriteLine($"IsCanceled: {task.IsCanceled}, IsCompleted: {task.IsCompleted}, Status: {task.Status}");
            while (task.Status == TaskStatus.Running)
            {
                Thread.Sleep(1000);
            }
            Console.WriteLine($"IsCanceled: {task.IsCanceled}, IsCompleted: {task.IsCompleted}, Status: {task.Status}");
        }
    }
}