// Задача 56: Задайте прямоугольный двумерный массив. 
// Напишите программу, которая будет находить строку с 
// наименьшей суммой элементов. Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке и выдаёт
// номер строки с наименьшей суммой элементов: 1 строка
try
{
    Console.WriteLine("Enter the number of rows of the table");
    int rows = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Enter the number of columns of the table");
    int cols = Convert.ToInt32(Console.ReadLine());

    if (rows < 1 || cols < 1)
        Console.WriteLine("Enter positive numbers only!");
    else
    {
        int[,] array = CreateAndFillArray(rows, cols);
        Console.WriteLine("The random array of {0} rows and {1} columns is:", rows, cols);
        PrintTable(array);
        Console.WriteLine("The number of row of table with minimum sum is {0}:", GetIndexRowMinSumElements(array) + 1);
    }
}
catch
{
    Console.WriteLine("You should enter numbers only!");
}

int[,] CreateAndFillArray(int n, int m)
{
    int[,] array = new int[n, m];
    for (int i = 0; i < n; i++)
        for (int j = 0; j < m; j++)
            array[i, j] = new Random().Next(0, 21);
    return array;
}

void PrintTable(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
            Console.Write("{0,5:d}", array[i, j]);
        Console.WriteLine();
    }
}

int GetSumElementsRowTable(int index, int[,] array)
{
    int sum = 0;
    for (int i = 0; i < array.GetLength(1); i++)
        sum += array[index, i];
    return sum;
}

int GetIndexRowMinSumElements(int[,] array)
{
    int indexResult = 0;
    int sumMin = GetSumElementsRowTable(0, array);
    for (int i = 1; i < array.GetLength(0); i++)
    {
        if (GetSumElementsRowTable(i, array) < sumMin)
        {
            sumMin = GetSumElementsRowTable(i, array);
            indexResult = i;
        }
    }
    return indexResult;
}
