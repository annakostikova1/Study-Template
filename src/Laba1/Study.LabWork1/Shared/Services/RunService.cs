using System;
using Study.LabWork1.Features.Task1;
using Study.LabWork1.Shared.Abstractions;

namespace Study.LabWork1.Shared.Services;

public class RunService : IRunService
{
    public void RunTask1()
    {
        var a = new RgbaPixel(200, 100, 50, 0.4);
        var b = new RgbaPixel(100, 200, 250, 0.8);

        Console.WriteLine("========================================");
        Console.WriteLine($" Исходный пиксель A : {a}");
        Console.WriteLine($" HEX представление A: {a.ToHex()}");
        Console.WriteLine("----------------------------------------");
        Console.WriteLine($" Исходный пиксель B : {b}");
        Console.WriteLine($" HEX представление B: {b.ToHex()}");
        Console.WriteLine("----------------------------------------");
        Console.WriteLine(" ОПЕРАЦИИ:");
        Console.WriteLine($" Сложение (A + B)   : {a + b}");
        Console.WriteLine($" Вычитание (A - B)  : {a - b}");
        Console.WriteLine($" Умножение (A * B)  : {a * b}");
        Console.WriteLine($" Скаляр (A * 2)     : {a * 2}");
        Console.WriteLine($" Скаляр (B / 2)     : {b / 2}");
        Console.WriteLine("----------------------------------------");
        Console.WriteLine(" СРАВНЕНИЕ:");
        Console.WriteLine($" Результат (A == B) : {a == b}");
        Console.WriteLine($" Результат (A != B) : {a != b}");
        Console.WriteLine("========================================");
    }

    public void RunTask2() { }

    public void RunTask3() { }
}
