using Extensions.SystemExt.CollectionsExt;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Extensions.SystemExt.MathExt
{
    public static class GeometricExtensions
    {
        public static double ToRadians(double degrees)
        {
            return (degrees * Math.PI) / 180;
        }

        public static IReadOnlyList<PointF> MovePointsToZero(
            IReadOnlyList<PointF> points)
        {
            var moveX = points.Select(p => p.X).Min();
            var moveY = points.Select(p => p.Y).Min();

            return points.Select(p =>
            {
                return new PointF
                (
                    x: (float)(p.X - moveX),
                    y: (float)(p.Y - moveY)
                );
            });
        }
    }
}
