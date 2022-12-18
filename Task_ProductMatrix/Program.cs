// Задача 58: Задайте две матрицы. Напишите программу,
//  которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20  2*3 + 4*3 =6+12=18   2*4 + 4*3=8+12=20
// 15 18  3*3 + 3*2 =9+6=15   3*4 + 2*3=12+6=18  

try
{
    Console.WriteLine("Enter the 4 numbers of sizes of 2 matrixes for multiplication:");
    Console.WriteLine("Enter the number of rows of the the first matrix");
    int rows1 = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Enter the number of columns of the first matrix");
    int cols1 = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Enter the number of rows of the second matrix");
    int rows2 = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Enter the number of columns of the second matrix");
    int cols2 = Convert.ToInt32(Console.ReadLine());

    if (rows1 < 1 || cols1 < 1 || rows2 < 1 || cols2 < 1)
        Console.WriteLine("Enter positive numbers only!");
    else if (rows2 != cols1)
        Console.WriteLine("Number of columns of 1 manrix must be equals to number of rows of 2 matrix!");
    else
    {
        int[,] array1 = CreateAndFillArray(rows1, cols1);
        Console.WriteLine("The random first array of {0} rows and {1} columns is:", rows1, cols1);
        PrintTable(array1);
        int[,] array2 = CreateAndFillArray(rows2, cols2);
        Console.WriteLine("The random second array of {0} rows and {1} columns is:", cols2, rows2);
        PrintTable(array2);
        int[,] resultArray = GetProductMatrixes(array1, array2);
        Console.WriteLine("The result of multiplication of 2 matrixes is:");
        PrintTable(resultArray);
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
            array[i, j] = new Random().Next(0, 10);
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

int[,] GetProductMatrixes(int[,] array1, int[,] array2)
{
    int size1 = array1.GetLength(1);
    int size2 = array1.GetLength(0);
    int size3 = array2.GetLength(1);
    int[,] resultArray = new int[size2, size3];
    for (int i = 0; i < size2; i++)
        for (int j = 0; j < size3; j++)
            for (int k = 0; k < size1; k++)
                resultArray[i, j] += array1[i, k] * array2[k, j];
    return resultArray;
}