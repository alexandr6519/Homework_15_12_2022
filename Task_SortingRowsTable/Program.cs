// Задача 54: Задайте двумерный массив. Напишите программу,
//  которая упорядочит по убыванию элементы каждой строки 
//  двумерного массива. Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
//8 4 4 2
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
        Console.WriteLine("This is array after sorting of rows:");
        SortEachRowOfTableDescending(array);
        PrintTable(array);
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
            array[i, j] = new Random().Next(-100, 101);
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

void SortRowOfTable(int index, int[,] array)
{
    for (int i = 0; i < array.GetLength(1) - 1; i++)
    {
        int indexMaxElement = i;
        for (int j = i + 1; j < array.GetLength(1); j++)
        {
            if (array[index, j] > array[index, indexMaxElement])
                indexMaxElement = j;
        }
        (array[index, i], array[index, indexMaxElement]) = (array[index, indexMaxElement], array[index, i]);
    }
}

void SortEachRowOfTableDescending(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
        SortRowOfTable(i, array);
}

