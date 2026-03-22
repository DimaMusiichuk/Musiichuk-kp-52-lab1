public class SortStatistics
{
    public int Comparisons { get; set; }
    public int Swaps { get; set;}
    public int Copies { get; set; }
    public int RecursiveCalls { get; set; }
    public int Passes { get; set; }
    public double ExecutionTime { get; set; }

    public void PrintStatistics()
    {
        Console.WriteLine("\n === Статистика сортування ===");
        Console.WriteLine($"Кількість порівнянь: {Comparisons}");
        Console.WriteLine($"Кількість перестановок: {Swaps}");
        Console.WriteLine($"Кількість копіювань: {Copies}");
        Console.WriteLine($"Рекурсивність викликів: {RecursiveCalls}");
        Console.WriteLine($"Проходів: {Passes}");
        Console.WriteLine($"Час виконання: {ExecutionTime}");
    }
}