using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Media.Imaging;
using Extensions.SystemExt.DrawingExt;

namespace QueenProblemWindow.Modifiers
{
    public static class _2DPainter
    {
        public static List<BitmapImage> Draw2DChessAreas(
            IReadOnlyList<List<Point>> solves, 
            int borderSize,
            int height = 1000,
            int width = 1000)
        {
            return solves.Select(p => Draw2DChessArea(
                p, 
                borderSize, 
                height, 
                width)).ToList();
        }

        public static BitmapImage Draw2DChessArea(
            IReadOnlyList<Point> points,
            int borderSize,
            int height,
            int width)
        {
            var bitmap = new Bitmap(width, height);
            var figWidth = width / borderSize;
            var figHeight = height / borderSize;

            var elipses = points.Select(p => new Rectangle(p.X * figWidth, p.Y * figHeight, figWidth, figHeight));
            var rects = new List<RectangleF>();
            for(var x = 0; x < borderSize; x++)
            {
                for (var y = 0; y < borderSize; y++)
                {
                    if((x + y) % 2 == 0)
                    {
                        rects.Add(new Rectangle(x*figWidth, y*figHeight, figWidth, figHeight));
                    }
                }
            }

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.LightGoldenrodYellow);
                g.FillRectangles(new SolidBrush(Color.Black), rects.ToArray());
                foreach (var el in elipses)
                {
                    g.FillEllipse(new SolidBrush(Color.Silver), el);
                }
            }
            return bitmap.BmpImage();
        }
    }
}
