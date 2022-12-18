// Задача 62. Напишите программу, которая заполнит 
// спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07
try
{
    Console.WriteLine("Enter the positive integer number");
    int size = Convert.ToInt32(Console.ReadLine());

    if (size < 1)
        Console.WriteLine("Enter positive number only!");
    else
    {
        int[,] array = new int[size, size];
        Console.WriteLine("The table of {0} x {0} filling by scroll is:", size);
        FillTable(array);
        PrintTable(array);
    }
}
catch
{
    Console.WriteLine("You should enter numbers only!");
}

void FillTable(int[,] array)
{
    int size = array.GetLength(0);
    int numberNext = 1;
    int direction = 0;
    int indexRowUp = 0;
    int indexRowDown = size - 1;
    int indexColumnLeft = 0;
    int indexColumnRigth = size - 1;
    while (numberNext <= size * size)
    {
        int[] resultArray = FillLineOfArray(array, indexRowUp, indexRowDown, indexColumnLeft, indexColumnRigth, direction, numberNext);
        direction++;
        numberNext = resultArray[4];
        indexRowUp = resultArray[0];
        indexRowDown = resultArray[1];
        indexColumnLeft = resultArray[2];
        indexColumnRigth = resultArray[3];
    }
}

int[] FillLineOfArray(int[,] array, int indexRowUp, int indexRowDown, int indexColumnLeft, int indexColumnRigth, int direction, int numberNext)
{
    int[] resultArray = new int[5];
    if (direction % 4 == 0)
    {
        for (int i = indexColumnLeft; i <= indexColumnRigth; i++)
        {
            array[indexRowUp, i] = numberNext;
            numberNext++;
        }
        indexRowUp++;
    }
    else if (direction % 4 == 1)
    {
        for (int i = indexRowUp; i <= indexRowDown; i++)
        {
            array[i, indexColumnRigth] = numberNext;
            numberNext++;
        }
        indexColumnRigth--;
    }
    else if (direction % 4 == 2)
    {
        for (int i = indexColumnRigth; i >= indexColumnLeft; i--)
        {
            array[indexRowDown, i] = numberNext;
            numberNext++;
        }
        indexRowDown--;
    }
    else if (direction % 4 == 3)
    {
        for (int i = indexRowDown; i >= indexRowUp; i--)
        {
            array[i, indexColumnLeft] = numberNext;
            numberNext++;
        }
        indexColumnLeft++;
    }
    resultArray[0] = indexRowUp;
    resultArray[1] = indexRowDown;
    resultArray[2] = indexColumnLeft;
    resultArray[3] = indexColumnRigth;
    resultArray[4] = numberNext;
    return resultArray;
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

