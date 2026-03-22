using System;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8; 
        Sorter sorter = new Sorter();
        sorter.InitCollection();

        bool isRunning = true;
        while (isRunning)
        {
            Console.WriteLine("\n=== МЕНЮ ===");
            Console.WriteLine("1. Ввести дані книги з клавіатури");
            Console.WriteLine("2. Згенерувати контрольні дані");
            Console.WriteLine("3. Вивести початковий/поточний каталог)");
            Console.WriteLine("4. Виконати сортування Merge Sort");
            Console.WriteLine("5. Вивести статистику сортування");
            Console.WriteLine("6. Знайти книги за першою літерою");
            Console.WriteLine("0. Вийти");
            Console.Write("Оберіть дію: ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Write("Введіть назву книги: ");
                string title = Console.ReadLine();
                
                Console.Write("Введіть автора: ");
                string author = Console.ReadLine();
                
                Console.Write("Введіть ID книги: ");
                int bookId;
                while (!int.TryParse(Console.ReadLine(), out bookId))
                {
                    Console.Write("Помилка! Введіть ціле число для ID: ");
                }

                Console.Write("Введіть рік видання: ");
                int year;
                while (!int.TryParse(Console.ReadLine(), out year))
                {
                    Console.Write("Помилка! Введіть ціле число для року: ");
                }

                sorter.AddRecord(new Record(title, author, bookId, year));
                Console.WriteLine("Книгу додано до каталогу");
            }
            else if (choice == "2")
            {
                sorter.GenerateControlData();
            }
            else if (choice == "3")
            {
                sorter.PrintCollection();
            }
            else if (choice == "4")
            {
                sorter.Sort();
            }
            else if (choice == "5")
            {
                if (sorter.stats != null)
                {
                    sorter.stats.PrintStatistics();
                }
                else
                {
                    Console.WriteLine("Спочатку виконайте сортування");
                }
            }
            else if (choice == "6")
            {
                Console.Write("Введіть першу літеру для пошуку: ");
                string input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input))
                {
                    sorter.FindBooksByLetter(input[0]);
                }
                else
                {
                    Console.WriteLine("Ви не ввели літеру.");
                }
            }
            else if (choice == "0")
            {
                isRunning = false;
            }
            else
            {
                Console.WriteLine("Невірний вибір.");
            }
        }
    }
}