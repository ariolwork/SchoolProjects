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
            IReadOnlyList<PointF> points, 
            double maxDiff = double.MaxValue)
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
            double proporcialX = (maxX - minX) / maxDiff;
            double proporcialY = (maxY - minY) / maxDiff;
            double proporcial = (proporcialX > proporcialY ? proporcialX : proporcialY);
            
            //main move parameters
            proporcial = proporcial > 1 ? proporcial : 1;
            double moveX = (maxX - minX) / 2;
            double moveY = (maxY - minY) / 2;

            return points.Select(p =>
            {
                return new PointF
                (
                    x: (float)((p.X * proporcial) - moveX),
                    y: (float)((p.Y * proporcial) - moveY)
                );
            });
        }
    }
}
