using System;
using log4net;
using log4net.Config;

namespace MatrixWalk
{
    /// <summary>
    /// Application's Main() method.
    /// </summary>
     public static class RotatingMatrixWalk
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(RotatingMatrixWalk));

        /// <summary>
        /// Walks a matrix as described in task condition. The size of the matrix is entered by the user
        /// and the result as printed to the console.
        /// </summary>
        public static void Main()
        {
            BasicConfigurator.Configure();
            logger.Debug("Asking for user input\n");

            Console.WriteLine("Enter a positive number (1-100)");
            string input = Console.ReadLine();
            int matrixSize;
            while (!int.TryParse(input, out matrixSize) || (matrixSize <= 0) || (matrixSize > 100))
            {
                logger.Warn("\nUser entered invalid number.\n");
                Console.WriteLine("You haven't entered number in allowed range.");
                input = Console.ReadLine();
            }

            logger.Debug("\nGot valid input, will walk the matrix now.\n");

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

            logger.Debug("\nWalk done.\n");
        }
    }
}
