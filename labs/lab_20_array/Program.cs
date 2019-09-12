using System;

namespace lab_20_array
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array1D = new int[10];//Array with size 10

            int sum = 0;
            int[,] array2D = new int[10, 10];//2D Array with size 10
            //
            for (int i = 0; i < array2D.GetLength(0); i++)
            {
                for (int j = 0; j < array2D.GetLength(1); j++)
                {
                    array2D[i, j] = i * i * j * j;
                }
            }
            //print sum
            for (int i = 0; i < array2D.GetLength(0); i++)
            {
                for (int j = 0; j < array2D.GetLength(1); j++)
                {
                    sum += array2D[i,j];
                }
            }
            Console.WriteLine(sum);

            int[,,] array3D = new int[10, 10, 10];//3D Array with size 10

            for (int i = 0; i < array3D.GetLength(0); i++)
            {
                for (int j = 0; j < array3D.GetLength(1); j++)
                {
                    for (int k= 0; k <  array3D.GetLength(2); k++)
                    {
                        array3D[i, j, k] = i * i * j * j * k * k;
                    }
                }
            }
            //print sum
            sum = 0;
            for (int i = 0; i < array3D.GetLength(0); i++)
            {
                for (int j = 0; j < array3D.GetLength(1); j++)
                {
                    for (int k= 0; k <  array3D.GetLength(2); k++)
                    {
                        sum += array3D[i, j, k];
                    }
                }
            }
            Console.WriteLine(sum);

            //literal array examples
            int[] arrayLiteral = new int[] { 1, 2, 3, 4, 5 };
            string[] stringLiteral = new string[] { "one", "two", "three" };

            //jagged array 
            Console.WriteLine("=== JAGGED ARRAY ===");
            int[][] myJaggedArray = new int[10][];
            myJaggedArray[0] = new int[5];
            Console.WriteLine();
            myJaggedArray[1] = new int[] { 1, 2, 3 };
        }
    }
}
