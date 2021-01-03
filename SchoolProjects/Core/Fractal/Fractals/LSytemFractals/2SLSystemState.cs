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
            [NotNull, ItemNotNull] IReadOnlyList<PointF> points)
        {
            StepCount = stepCount;
            Points = points ?? throw new Exception($"NotNull parameter {points} exception");
        }

        public bool Equals(int stepCount)
        {
            return stepCount == StepCount;
        }

        public int StepCount { get; }

        [NotNull, ItemNotNull]
        public IReadOnlyList<PointF> Points { get; }
    }
}
