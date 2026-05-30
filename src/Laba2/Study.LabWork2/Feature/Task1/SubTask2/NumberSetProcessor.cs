using System;
using System.Threading;
using System.Diagnostics;
using System.Collections.Generic;
using Study.LabWork2.Abstractions.Feature.Task1.SubTask2;
using Study.LabWork2.Abstractions.Feature.Task1.SubTask2.DtoModels;

namespace Study.LabWork2.Feature.Task1.SubTask2;

public sealed class NumberSetProcessor : INumberSetProcessor
{
    private ProcessingResultDto? res;
    private static readonly object lockObj = new();

    public void Process()
    {
        var list = new List<ResultEntryDto>();
        int total = 0;
        int count = 12;
        Thread[] threads = new Thread[count];
        Stopwatch sw = Stopwatch.StartNew();

        for (int i = 0; i < count; i++)
        {
            int num = i + 1;
            threads[i] = new Thread(() =>
            {
                int val = num * 100;
                var item = new ResultEntryDto
                {
                    SetNumber = num,
                    Sum = val,
                    ThreadId = Environment.CurrentManagedThreadId
                };

                lock (lockObj)
                {
                    list.Add(item);
                    total += val;
                }
            });
            threads[i].Start();
        }

        foreach (var t in threads) t.Join();
        sw.Stop();

        res = new ProcessingResultDto
        {
            Results = list,
            TotalSum = total,
            ExecutionTime = sw.Elapsed,
            ProcessedSetsCount = count
        };
    }

    public ProcessingResultDto GetResult()
    {
        if (res == null)
        {
            Process();
        }
        return res!;
    }
}
