using System;
using System.Collections.Generic;

namespace MatrixWalk
{
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

        public enum Direction
        {
            DownRight, Down, DownLeft, Left, UpLeft, Up, UpRight, Right
        }

        public static int Count
        {
            get
            {
                return COUNT;
            }
        }

        public static Direction GetFirst()
        {
            return Direction.DownRight;
        }

        public static Direction GetNext(Direction current)
        {
            return (Direction)(((int)current + 1) % COUNT);
        }

        public static Tuple<int, int> GetDelta(Direction current)
        {
            return deltas[current];
        }
    }
}
