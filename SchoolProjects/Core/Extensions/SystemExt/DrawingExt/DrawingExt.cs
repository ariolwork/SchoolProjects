using System.Drawing;

namespace Extensions.SystemExt.DrawingExt
{
    public static class PointFExt
    {
        public static PointF Add(
            this PointF first,
            PointF secnd)
        {
            return new PointF(
                x: first.X + secnd.X, 
                y: first.Y + secnd.Y);
        }
    }
}
