using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace QueenProblem
{
    public static class QueenProblem
    {
        public static List<List<Point>> SolveProblem(int bordSize)
        {
            var coordinates = new List<List<Point>>();

            var xCoordinates = new bool[bordSize];
            var yCoordinates = new bool[bordSize];
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
            if (!(xLineIsFull.Any(v => !v)
                || yLineIsFull.Any(v => !v)))
            {
                if(!points.Any(c => coordinates.All(p => c.Contains(p))))
                    points.Add(coordinates);
            }

            for (var xLine = 0; xLine < xLineIsFull.Length; xLine++)
            {
                if (xLineIsFull[xLine])
                    continue;
                for (var yLine = 0; yLine < yLineIsFull.Length; yLine++)
                {
                    if (yLineIsFull[yLine] 
                        || coordinates.Any(p => Math.Abs(p.X - xLine) == Math.Abs(p.Y - yLine)))
                        continue;
                    xLineIsFull[xLine] = true;
                    yLineIsFull[yLine] = true;
                    var newList = new List<Point>(coordinates);
                    newList.Add(new Point(xLine, yLine));
                    GetCoordinates(
                        ref xLineIsFull, 
                        ref yLineIsFull, 
                        points, 
                        newList);
                    xLineIsFull[xLine] = false;
                    yLineIsFull[yLine] = false;
                }
            }
        }
    }
}
