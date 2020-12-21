using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Fractal.Fractals.LSytemFractals
{
    public sealed class _2SLSystemState
    {
        public _2SLSystemState(
            int stepCount,
            double zoom,
            PointF center,
            [NotNull, ItemNotNull] IReadOnlyList<PointF> points)
        {
            StepCount = stepCount;
            Zoom = zoom;
            Points = points ?? throw new Exception($"NotNull parameter {points} exception");
            Center = center;
        }

        public bool Equals(
            int stepCount,
            double zoom,
            PointF center)
        {
            return stepCount == StepCount && zoom == Zoom && center == Center;
        }

        public int StepCount { get; }

        public double Zoom { get; }

        [NotNull]
        public PointF Center { get; }

        [NotNull, ItemNotNull]
        public IReadOnlyList<PointF> Points { get; }
    }
}
