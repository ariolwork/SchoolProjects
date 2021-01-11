using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace QueenProblemWindow.Modifiers
{
    public static class TextFormatter
    {
        public static string FormatPointListIntoString(List<List<Point>> solves) 
        {
            return string.Join(
                Environment.NewLine,
                solves.Select(e => 
                {
                    return string.Join("; ", e.Select(point => $"({point.X + 1}, {point.Y + 1})"));
                }));
        }
    }
}
