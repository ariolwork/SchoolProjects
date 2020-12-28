using Extensions.SystemExt.CollectionsExt;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Extensions.SystemExt.MathExt
{
    public static class GeometricExtensions
    {
        public static double ToRadians(double degrees)
        {
            return (degrees * Math.PI) / 180;
        }

        public static IReadOnlyList<PointF> CenterlizePoints(
            IReadOnlyList<PointF> points)
        {
            var maxX = double.MinValue;
            var maxY = double.MinValue;
            var minX = double.MaxValue;
            var minY = double.MaxValue;
            points.ForEach(point =>
            {
                maxX = maxX < point.X ? point.X : maxX;
                maxY = maxY < point.Y ? point.Y : maxY;
                minX = minX > point.X ? point.X : minX;
                minY = minY > point.Y ? point.Y : minY;
            });
            
            double moveX = (maxX - minX) / 2;
            if ((moveX < 0 && maxX <= 0) || (moveX > 0 && minX >= 0))
            {
                moveX *= -1;
            }

            double moveY = (maxY - minY) / 2;
            if ((moveY < 0 && maxY <= 0) || (moveY > 0 && minY >= 0))
            {
                moveY *= -1;
            }

            return points.Select(p =>
            {
                return new PointF
                (
                    x: (float)(p.X + moveX),
                    y: (float)(p.Y + moveY)
                );
            });
        }
    }
}
