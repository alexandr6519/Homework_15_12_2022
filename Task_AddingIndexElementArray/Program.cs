// Задача 60.Сформируйте трёхмерный массив из неповторяющих
// ся (HARD - случайные уникальные) двузначных чисел.
//  Напишите программу, которая будет построчно выводить 
//  массив, добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)
Console.WriteLine("Input 3 integer positive number for creating of 3D array");
try
{
    Console.WriteLine("Input the first size of array");
    int size1 = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Input the second size of array");
    int size2 = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Input the third size of array");
    int size3 = Convert.ToInt32(Console.ReadLine());
    if (size1 < 1 || size2 < 1 || size3 < 1) Console.WriteLine("You should enter POSITIVE number only!");
    else
    {
        int[,,] array = CreateArray3DRandom(size1, size2, size3);
        Console.WriteLine("This is our 3D array of randoming elements: ");
        PrintArray3D(array);
        Console.WriteLine("This is our 3D array with index of elements: ");
        PrintArrayWithIndex(array);
    }
}
catch
{
    Console.WriteLine("You should enter integer number only!!!");
}

int[,,] CreateArray3DRandom(int size1, int size2, int size3)
{
    int[,,] array = new int[size1, size2, size3];
    for (int i = 0; i < size1; i++)
        for (int j = 0; j < size2; j++)
            for (int k = 0; k < size3; k++)
                array[i, j, k] = GetUniqueElement(array);
    return array;
}

bool IsUniqueElement(int element, int[,,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
        for (int j = 0; j < array.GetLength(1); j++)
            for (int k = 0; k < array.GetLength(2); k++)
                if (array[i, j, k] == element) return false;
    return true;
}

int GetUniqueElement(int[,,] array)
{
    int temp = new Random().Next(1, 100);
    while (!IsUniqueElement(temp, array))
        temp = new Random().Next(1, 100);
    return temp;
}

void PrintArray3D(int[,,] array)
{

    for (int i = 0; i < array.GetLength(0); i++)
    {
        Console.Write("{");
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write("(");
            for (int k = 0; k < array.GetLength(2); k++)
                if (k == array.GetLength(2) - 1) 
                    Console.Write($" {array[i, j, k]})");
                else Console.Write($" {array[i, j, k]},");
            Console.WriteLine();
        }
        Console.WriteLine("}");
    }
}

void PrintArrayWithIndex(int[,,] array)
{

    for (int i = 0; i < array.GetLength(0); i++)
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write("(");
            for (int k = 0; k < array.GetLength(2); k++)
                if (k == array.GetLength(2) - 1) 
                Console.Write(" {0}({1},{2},{3}))", array[i, j, k], i, j, k);
                else Console.Write(" {0}({1},{2},{3}),", array[i, j, k], i, j, k);
            Console.WriteLine();
        }
}