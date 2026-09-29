using System;

class Program
{
    static readonly Random random = new Random();

    static int ReadPositiveInt(string message)
    {
        while (true)
        {
            Console.Write(message);

            if (int.TryParse(
                Console.ReadLine(),
                out int value) &&
                value > 0)
            {
                return value;
            }

            Console.WriteLine(
                "Помилка: введіть додатне ціле число."
            );
        }
    }

    static int ReadInt(string message)
    {
        while (true)
        {
            Console.Write(message);

            if (int.TryParse(
                Console.ReadLine(),
                out int value))
            {
                return value;
            }

            Console.WriteLine(
                "Помилка: введіть ціле число."
            );
        }
    }

    static int[,] ReadMatrix(
        int n,
        string name)
    {
        int[,] matrix =
            new int[n, n];

        Console.WriteLine();
        Console.WriteLine(
            "=== Введення матриці {0} ===",
            name
        );

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                matrix[i, j] =
                    ReadInt(
                        $"{name}[{i + 1},{j + 1}] = "
                    );
            }
        }

        return matrix;
    }

    static int[,] GenerateMatrix(int n)
    {
        int[,] matrix =
            new int[n, n];

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                matrix[i, j] =
                    random.Next(-100, 101);
            }
        }

        return matrix;
    }

    static void PrintMatrix(
        int[,] matrix,
        string name)
    {
        Console.WriteLine();
        Console.WriteLine(name + ":");

        int n =
            matrix.GetLength(0);

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(
                    "{0,6}",
                    matrix[i, j]
                );
            }

            Console.WriteLine();
        }
    }

    static void ReplaceEvenColumnsWithOddRows(
        int[,] a,
        int[,] b)
    {
        int n =
            a.GetLength(0);

        for (int column = 1;
             column < n;
             column += 2)
        {
            int sourceRow =
                column - 1;

            for (int i = 0; i < n; i++)
            {
                a[i, column] =
                    b[sourceRow, i];
            }
        }
    }

    static void ExecuteTask()
    {
        int n =
            ReadPositiveInt(
                "Введіть розмірність квадратних матриць n: "
            );

        Console.WriteLine();
        Console.WriteLine("1 - введення з клавіатури");
        Console.WriteLine("2 - випадкові числа [-100; 100]");

        int choice =
            ReadInt("Ваш вибір: ");

        while (choice != 1 && choice != 2)
        {
            Console.Write(
                "Помилка. Введіть 1 або 2: "
            );

            choice =
                ReadInt("");
        }

        int[,] a;
        int[,] b;

        if (choice == 1)
        {
            a =
                ReadMatrix(n, "A");

            b =
                ReadMatrix(n, "B");
        }
        else
        {
            a =
                GenerateMatrix(n);

            b =
                GenerateMatrix(n);
        }

        PrintMatrix(
            a,
            "Початкова матриця A"
        );

        PrintMatrix(
            b,
            "Матриця B"
        );

        ReplaceEvenColumnsWithOddRows(
            a,
            b
        );

        PrintMatrix(
            a,
            "Результат"
        );
    }

    static void Main()
    {
        int menu;

        do
        {
            Console.Clear();

            Console.WriteLine("=== ЗАВДАННЯ №5 ===");
            Console.WriteLine();
            Console.WriteLine(
                "Парні стовпці A замінюються непарними рядками B"
            );
            Console.WriteLine();

            ExecuteTask();

            Console.WriteLine();
            Console.WriteLine("1 - виконати ще раз");
            Console.WriteLine("0 - вийти");
            Console.Write("Ваш вибір: ");

            while (!int.TryParse(
                       Console.ReadLine(),
                       out menu) ||
                   (menu != 0 && menu != 1))
            {
                Console.Write(
                    "Помилка. Введіть 1 або 0: "
                );
            }

        } while (menu != 0);

        Console.WriteLine("Програму завершено.");
    }
}