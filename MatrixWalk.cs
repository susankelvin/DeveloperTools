using System;

namespace MatrixWalk
{
    class RotatingMatrixWalk
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a positive number (1-100)");
            string input = Console.ReadLine();
            int matrixSize;
            while (!int.TryParse(input, out matrixSize) || matrixSize <= 0 || matrixSize > 100)
            {
                Console.WriteLine("You haven't entered number in allowed range.");
                input = Console.ReadLine();
            }

            int[,] matrix = new int[matrixSize, matrixSize];
            MatrixWalker.Walk(matrix);

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0,3}", matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
