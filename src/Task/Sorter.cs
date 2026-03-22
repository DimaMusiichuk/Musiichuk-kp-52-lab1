using System;
using System.Diagnostics;

public class Sorter
{
    private Record[] collection;
    private int count; 
    public SortStatistics stats; 
    public void InitCollection()
    {
        collection = new Record[100]; 
        count = 0; 
        stats = new SortStatistics();
    }

    public void AddRecord(Record record)
    {
        if (count < collection.Length)
        {
            collection[count] = record; 
            count++;
        }
        else
        {
            Console.WriteLine("Помилка: Каталог повністю заповнений");
        }
    }

    public void PrintCollection()
    {
        if (count == 0)
        {
            Console.WriteLine("Каталог порожній");
            return;
        }

        Console.WriteLine("\n=== Поточний каталог книг ===");
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine(collection[i].ToString());
        }
    }

    public void GenerateControlData()
    {
        InitCollection(); 
        AddRecord(new Record("Війна і мир", "Л. Толстой", 1, 2023));
        AddRecord(new Record("Гаррі Поттер", "Дж. Роулінг", 2, 2005));
        AddRecord(new Record("Алгоритми", "Кормен", 3, 1990));
        AddRecord(new Record("Гаррі Поттер", "Дж. Роулінг", 4, 1997)); 
        AddRecord(new Record("Кобзар", "Т. Шевченко", 5, 1840));
        AddRecord(new Record("Атлант розправив плечі", "А. Ренд", 6, 1957));
    }


    public void Sort()
    {
        if (count <= 1) return; 
        
        stats = new SortStatistics(); 
        Stopwatch timer = Stopwatch.StartNew();

        MergeSort(collection, 0, count - 1);

        timer.Stop();
        stats.ExecutionTime = timer.Elapsed.TotalMilliseconds;
    }

    private void MergeSort(Record[] array, int left, int right)
    {
        stats.RecursiveCalls++;

        if (left < right)
        {
            int mid = left + (right - left) / 2;

            MergeSort(array, left, mid);
            MergeSort(array, mid + 1, right);

            Merge(array, left, mid, right);

            stats.Passes++;
            Console.WriteLine($"\n[Проміжний етап {stats.Passes}] Злиття діапазонів [{left}..{mid}] та [{mid+1}..{right}]:");
            for (int i = left; i <= right; i++)
            {
                Console.WriteLine($"  {array[i].Title} ({array[i].Year})");
            }
        }
    }

    private void Merge(Record[] array, int left, int mid, int right)
    {
        int n1 = mid - left + 1;
        int n2 = right - mid;

        Record[] L = new Record[n1];
        Record[] R = new Record[n2];

        for (int i = 0; i < n1; i++)
        {
            L[i] = array[left + i]; stats.Copies++;
        }

        for (int j = 0; j < n2; j++)
        {
            R[j] = array[mid + 1 + j]; stats.Copies++;
        }

        int i_idx = 0, j_idx = 0;
        int k = left;

        while (i_idx < n1 && j_idx < n2)
        {
            stats.Comparisons++;
            int titleCompare = string.Compare(L[i_idx].Title, R[j_idx].Title, StringComparison.OrdinalIgnoreCase);

            if (titleCompare < 0)
            {
                array[k] = L[i_idx];
                i_idx++;
            }
            else if (titleCompare > 0)
            {
                array[k] = R[j_idx];
                j_idx++;
            }
            else
            {
                stats.Comparisons++;
                if (L[i_idx].Year <= R[j_idx].Year)
                {
                    array[k] = L[i_idx];
                    i_idx++;
                }
                else
                {
                    array[k] = R[j_idx];
                    j_idx++;
                }
            }
            stats.Copies++;
            k++;
        }

        while (i_idx < n1) { array[k] = L[i_idx]; i_idx++; k++; stats.Copies++; }
        while (j_idx < n2) { array[k] = R[j_idx]; j_idx++; k++; stats.Copies++; }
    }


    public void FindBooksByLetter(char letter)
    {
        if (count == 0) return;

        string target = letter.ToString().ToLower();
        int startIndex = -1;
        int endIndex = -1;

        for (int i = 0; i < count; i++)
        {
            if (collection[i].Title.ToLower().StartsWith(target))
            {
                if (startIndex == -1) startIndex = i;
                endIndex = i; 
            }
        }

        if (startIndex != -1)
        {
            Console.WriteLine($"\nЗнайдено книги на літеру '{char.ToUpper(letter)}'.");
            Console.WriteLine($"Межі діапазону в масиві: від індексу {startIndex} до {endIndex}");
            for (int i = startIndex; i <= endIndex; i++)
            {
                Console.WriteLine($"  {collection[i].ToString()}");
            }
        }
        else
        {
            Console.WriteLine($"\nКниг, що починаються на літеру '{letter}', не знайдено.");
        }
    }
}