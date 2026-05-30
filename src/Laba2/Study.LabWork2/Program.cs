using System;
using Study.LabWork2.Feature.Task1.SubTask1;
using Study.LabWork2.Feature.Task1.SubTask2;

namespace Study.LabWork2;

internal class Program
{
    private static void Main()
    {
      
        var monitor = new MonitorService();
        var mutex = new MutexService();
        var semaphore = new SemaphoreService();

        var resMonitor = monitor.CountPrimes(1, 10000, 4);
        var resMutex = mutex.CountPrimes(1, 10000, 4);
        var resSem = semaphore.CountPrimes(1, 10000, 4);

        Console.WriteLine("задание 1.1 простые числа");
        Console.WriteLine($" {resMonitor.SynchronizationType.ToLower()}: найдено {resMonitor.PrimeCount} за {resMonitor.ExecutionTime.TotalMilliseconds:F2} мс");
        Console.WriteLine($" {resMutex.SynchronizationType.ToLower()}: найдено {resMutex.PrimeCount} за {resMutex.ExecutionTime.TotalMilliseconds:F2} мс");
        Console.WriteLine($" {resSem.SynchronizationType.ToLower()}: найдено {resSem.PrimeCount} за {resSem.ExecutionTime.TotalMilliseconds:F2} мс");

        Console.WriteLine("задание 1.2 обработка наборов");
        var processor = new NumberSetProcessor();
        var res12 = processor.GetResult();

        foreach (var item in res12.Results)
        {
            Console.WriteLine($" набор №{item.SetNumber} поток id: {item.ThreadId} сумма: {item.Sum}");
        }

        Console.WriteLine($" общий итог totalsum: {res12.TotalSum}");
        Console.WriteLine($" время выполнения: {res12.ExecutionTime.TotalMilliseconds:F2} мс");
        Console.ReadKey();
    }
}
