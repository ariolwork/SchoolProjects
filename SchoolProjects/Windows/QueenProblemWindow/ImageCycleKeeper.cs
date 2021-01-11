using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Imaging;

namespace QueenProblemWindow
{
    class ImageCycleKeeper
    {
        List<BitmapImage> _images;
        int? curentIndex;

        public ImageCycleKeeper(List<BitmapImage> images)
        {
            _images = images;
            if (images != null && images.Count > 0)
            {
                curentIndex = 0;
            }
            else
            {
                curentIndex = null;
            }
        }
        public BitmapImage GetCurrent()
        {
            if (curentIndex == null)
                return null;

            return _images[curentIndex ?? 0];
        }

        public BitmapImage GetNext()
        {
            if (curentIndex == null)
                return null;

            curentIndex++;
            if (curentIndex >= _images.Count)
            {
                curentIndex = 0;
            }

            return _images[curentIndex ?? 0];
        }
        public BitmapImage GetPrevious()
        {
            if (curentIndex == null)
                return null;

            curentIndex--;
            if (curentIndex < 0)
            {
                curentIndex = _images.Count - 1;
            }

            return _images[curentIndex ?? 0];
        }
    }
}
