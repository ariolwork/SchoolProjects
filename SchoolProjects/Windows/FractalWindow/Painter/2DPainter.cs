using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace FractalWindow.Painter
{
    public static class _2DPainter
    {
        public static Bitmap Draw2DPoints(IReadOnlyList<PointF> points, int height = 10000, int width= 10000)
        {
            var bitmap = new Bitmap(width, height);

            if (points == null || points.Count == 0)
            {
                return bitmap;
            }


            var zoomheight = height * 0.92;
            var zoomwidth = width * 0.92;

            var xMax = points.Select(x => x.X).Max();
            var yMax = points.Select(x => x.Y).Max();
            var xzoom = zoomwidth / ZeroToOneOnly(xMax);
            var yzoom = zoomheight / ZeroToOneOnly(yMax);
            var zoom = xzoom < yzoom ? xzoom : yzoom;
            var zoomPoints = points.Select(p => new PointF((float)(p.X * zoom), (float)(p.Y*zoom))).ToList();
            var newPoint = zoomPoints.Select(p => new Point(
                (int)(p.X + width * 0.04),
                (int)(p.Y + height * 0.04))).ToList();
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.White);
                for(int i = 0; i < newPoint.Count - 1; i++)
                {
                    var from = newPoint[i];
                    var to = newPoint[i+1];
                    g.DrawLine(new Pen(Color.Black, 30), from, to);
                }
            }
            return bitmap;
        }

        private static double ZeroToOneOnly(double val)
        {
            if (val <= 0.0000001 && val >= -0.0000001)
            {
                return 1;
            }
            else return val;
        }
    }
}
