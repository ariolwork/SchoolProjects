using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace QueenProblem
{
    public static class QueenProblem
    {
        public static List<List<Point>> SolveProblem(int boardSize)
        {
            var coordinates = new List<List<Point>>();

            var xCoordinates = new bool[boardSize];
            var yCoordinates = new bool[boardSize];
            GetCoordinates(
                xLineIsFull: ref xCoordinates,
                yLineIsFull: ref yCoordinates,
                points: coordinates,
                coordinates: new List<Point>()
                );
            return coordinates;
        }

        private static void GetCoordinates(
            ref bool[] xLineIsFull,
            ref bool[] yLineIsFull,
            List<List<Point>> points,
            List<Point> coordinates)
        {
            if (xLineIsFull.Any(v => !v)
                || yLineIsFull.Any(v => !v))
            {
                points.Add(coordinates);
            }

            for (var xLine = 0; xLine < xLineIsFull.Length; xLine++)
            {
                if (xLineIsFull[xLine])
                    continue;
                for (var yLine = 0; yLine < yLineIsFull.Length; yLine++)
                {
                    if (yLineIsFull[yLine])
                        continue;
                    xLineIsFull[xLine] = true;
                    yLineIsFull[yLine] = true;
                    GetCoordinates(
                        ref xLineIsFull, 
                        ref yLineIsFull, 
                        points, 
                        coordinates);
                    xLineIsFull[xLine] = false;
                    yLineIsFull[yLine] = false;
                }
            }
        }
    }
}
