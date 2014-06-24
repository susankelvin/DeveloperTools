using System;

namespace MatrixWalk
{
    /// <summary>
    /// Walks a matrix as per task condition.
    /// </summary>
    public static class MatrixWalker
    {
        /// <summary>
        /// Walks the matrix as per task condition.
        /// </summary>
        /// <param name="matrix">Matrix to walk.</param>
        /// <remarks>Task condition is a bit too long to copy it here :-)</remarks>
        public static void Walk(int[,] matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException("matrix cannot be null.");
            }

            int currentStep = 1;
            int row;
            int column;
            int matrixCellsUnvisited = matrix.GetLength(0) * matrix.GetLength(1);
            DirectionManager.Direction currentDirection = DirectionManager.GetFirst();

            GetWalkOrigin(matrix, out row, out column);
            while (true)
            {
                matrix[row, column] = currentStep;
                if (--matrixCellsUnvisited == 0)
                {
                    break;
                }

                if (!TryMove(matrix, ref row, ref column, ref currentDirection))
                {
                    GetWalkOrigin(matrix, out row, out column);
                    currentDirection = DirectionManager.GetFirst();
                }

                currentStep++;
            }
        }

        /// <summary>
        /// Tries to find available neighbour cell as per task condition.
        /// If successful updates the ref params with the coordinates of next cell the wlak goes through.
        /// </summary>
        /// <param name="matrix">Matrix</param>
        /// <param name="row">Row index of the current cell.</param>
        /// <param name="column">Column index of the current cell.</param>
        /// <param name="direction">current direction.</param>
        /// <returns>True, if neighbour cell can be visited, False otherwise.</returns>
        private static bool TryMove(int[,] matrix, ref int row, ref int column, ref DirectionManager.Direction direction)
        {
            int newRow;
            int newColumn;
            Tuple<int, int> deltas;
            DirectionManager.Direction currentDirection = direction;

            for (int i = 0; i < DirectionManager.Count - 1; i++)
            {
                deltas = DirectionManager.GetDelta(currentDirection);
                newRow = row + deltas.Item1;
                newColumn = column + deltas.Item2;
                if (InsideMatrix(matrix, newRow, newColumn) && (matrix[newRow, newColumn] == 0))
                {
                    row = newRow;
                    column = newColumn;
                    direction = currentDirection;
                    return true;
                }
                else
                {
                    currentDirection = DirectionManager.GetNext(currentDirection);
                }
            }

            return false;
        }

        /// <summary>
        /// Returns the coordinates of the first unvisited cell as per task condition.
        /// </summary>
        /// <param name="matrix">Matrix</param>
        /// <param name="row">Row index.</param>
        /// <param name="column">Column index.</param>
        private static void GetWalkOrigin(int[,] matrix, out int row, out int column)
        {
            row = 0;
            column = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        row = i;
                        column = j;
                        return;
                    }
                }
            }
        }

        private static bool InsideMatrix(int[,] matrix, int row, int column)
        {
            bool rowValid = (0 <= row) && (row < matrix.GetLength(0));
            bool columnValid = (0 <= column) && (column < matrix.GetLength(1));
            return rowValid && columnValid;
        }
    }
}
