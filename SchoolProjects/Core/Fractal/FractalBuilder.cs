using Fractal.Fractals;
using Fractal.Fractals.LSytemFractals;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;

namespace Fractal
{
    public static class FractalBuilder
    {
        public static IFractal Get2DLSystemFractal(
            [NotNull] string startSystemСondition,
            double rotateAngle,
            [NotNull] string generativeRules)
        {
            return new Fractal2DByLSystem(
                startSystemСondition: startSystemСondition,
                rotateAngle: rotateAngle,
                generativeRules: GenerativeRules.FromString(generativeRules));
        }
    }
}
