using System;
using System.Threading;
using System.Diagnostics;
using System.Collections.Generic;
using Study.LabWork2.Abstractions.Feature.Task1.SubTask1;
using Study.LabWork2.Abstractions.Feature.Task1.SubTask1.DtoModels;

namespace Study.LabWork2.Feature.Task1.SubTask1;

public sealed class SemaphoreService : IPrimeCounter
{
    private static readonly Semaphore sem = new(1, 1);

    public string GetVersionName() => "Semaphore";

    public PrimeCountResultDto CountPrimes(int start, int end, int threadsCount)
    {
        int total = 0;
        List<int> list = new();
        Thread[] threads = new Thread[threadsCount];
        int step = (end - start + 1) / threadsCount;
        Stopwatch sw = Stopwatch.StartNew();

        for (int i = 0; i < threadsCount; i++)
        {
            int tStart = start + i * step;
            int tEnd = (i == threadsCount - 1) ? end : tStart + step - 1;

            threads[i] = new Thread(() =>
            {
                for (int num = tStart; num <= tEnd; num++)
                {
                    if (IsPrime(num))
                    {
                        sem.WaitOne();
                        try
                        {
                            total++;
                            list.Add(num);
                        }
                        finally
                        {
                            sem.Release();
                        }
                    }
                }
            });
            threads[i].Start();
        }

        foreach (var t in threads) t.Join();
        sw.Stop();

        return new PrimeCountResultDto
        {
            PrimeCount = total,
            ExecutionTime = sw.Elapsed,
            ThreadCount = threadsCount,
            SynchronizationType = GetVersionName(),
            FoundPrimes = list
        };
    }

    private static bool IsPrime(int num)
    {
        if (num < 2) return false;
        for (int i = 2; i * i <= num; i++)
        {
            if (num % i == 0) return false;
        }
        return true;
    }
}
