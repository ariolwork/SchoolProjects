using Fractal;
using Fractal.Fractals;
using FractalWindow.Painter;
using System.Windows.Media.Imaging;

namespace FractalWindow
{
    public sealed class FractaKeeper
    {
        private IFractal _fractal;

        public BitmapImage BuildNewFractal(
            string startSystemСondition,
            string rotateAngle,
            string generativeRules,
            string systemStepCount)
        {
            SetFractalIfRequired(
                startSystemСondition: startSystemСondition,
                rotateAngle: rotateAngle,
                generativeRules: generativeRules);

            var points = _fractal.Points(
                stepCount: int.Parse(systemStepCount));

            return _2DPainter.Draw2DPoints(points);
        }

        private void SetFractalIfRequired(
            string startSystemСondition,
            string rotateAngle,
            string generativeRules)
        {
            _fractal = FractalBuilder.Get2DLSystemFractal(
                startSystemСondition: startSystemСondition,
                rotateAngle: int.Parse(rotateAngle),
                generativeRules: generativeRules);
        }
    }
}
