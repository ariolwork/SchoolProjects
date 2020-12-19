using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Fractal.Fractals
{
    public sealed class Fractal2DByLSystem : IFractal
    {
        public Fractal2DByLSystem(
            [NotNull] string )
        {

        }
        
        public IReadOnlyList<Point> Points { get; }
    }
}
