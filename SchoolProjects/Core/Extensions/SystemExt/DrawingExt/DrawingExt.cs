using System.Drawing;
using System.Windows.Media.Imaging;

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

        public static BitmapImage BmpImage(this Bitmap bmp)
        {
            using (var memory = new System.IO.MemoryStream())
            {
                bmp.Save(memory, System.Drawing.Imaging.ImageFormat.Png);
                memory.Position = 0;

                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                bitmapImage.Freeze();

                return bitmapImage;
            }
        }
    }
}
