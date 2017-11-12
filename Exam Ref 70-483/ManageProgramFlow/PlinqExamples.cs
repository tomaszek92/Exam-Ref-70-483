using System;
using System.Linq;

namespace ManageProgramFlow
{
    public class PlinqExamples
    {
        public static void AsOrdered()
        {
            var numbers = Enumerable.Range(0, 200);
            ParallelQuery<int> parallelResult = numbers
                .AsParallel()
                .AsOrdered()
                .Where(number => number % 2 == 0);

            foreach (int number in parallelResult.Take(5))
            {
                Console.WriteLine(number);
            }
        }

        public static void ExceptionsHandling()
        {
            var numbers = Enumerable.Range(0, 200);
            try
            {
                numbers
                    .AsParallel()
                    .Where(number =>
                    {
                        if (number % 10 == 0)
                        {
                            throw new Exception();
                        }
                        return number % 2 == 0;
                    })
                    .ForAll(Console.WriteLine);
            }
            catch (AggregateException e)
            {
                Console.WriteLine($"There were {e.InnerExceptions.Count} exceptions");
            }
        }
    }
}