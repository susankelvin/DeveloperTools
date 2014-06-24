using System;
using System.Collections.Generic;

namespace MatrixWalk
{
    /// <summary>
    /// Manages the direction of the walk.
    /// </summary>
    public static class DirectionManager
    {
        private const int COUNT = 8;
        private static readonly Dictionary<Direction, Tuple<int, int>> deltas = new Dictionary<Direction, Tuple<int, int>>()
        {
            {Direction.DownRight, new Tuple<int, int>(1, 1)},
            {Direction.Down, new Tuple<int, int>(1, 0)},
            {Direction.DownLeft, new Tuple<int, int>(1, -1)},
            {Direction.Left, new Tuple<int, int>(0, -1)},
            {Direction.UpLeft, new Tuple<int, int>(-1, -1)},
            {Direction.Up, new Tuple<int, int>(-1, 0)},
            {Direction.UpRight, new Tuple<int, int>(-1, 1)},
            {Direction.Right, new Tuple<int, int>(0, 1)}
        };

        /// <summary>
        /// Possilbe directions.
        /// </summary>
        public enum Direction
        {
            DownRight, Down, DownLeft, Left, UpLeft, Up, UpRight, Right
        }

        /// <summary>
        /// Number of available directions.
        /// </summary>
        public static int Count
        {
            get
            {
                return COUNT;
            }
        }

        /// <summary>
        /// Get the first direction to walk in.
        /// </summary>
        /// <returns>First direction.</returns>
        public static Direction GetFirst()
        {
            return Direction.DownRight;
        }

        /// <summary>
        /// Get the next direction relative to current one in cyclic order.
        /// </summary>
        /// <param name="current">current direction.</param>
        /// <returns>Next direction.</returns>
        public static Direction GetNext(Direction current)
        {
            return (Direction)(((int)current + 1) % COUNT);
        }

        /// <summary>
        /// Returns the offset of the next step relative to current position and direction.
        /// </summary>
        /// <param name="current">Current direction.</param>
        /// <returns>Delta in position.</returns>
        public static Tuple<int, int> GetDelta(Direction current)
        {
            return deltas[current];
        }
    }
}
