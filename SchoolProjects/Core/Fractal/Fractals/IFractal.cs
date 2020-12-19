using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Fractal.Fractals
{
    public interface IFractal
    {
        [NotNull, ItemNotNull]
        IReadOnlyList<Point> Points { get; }
    }
}
