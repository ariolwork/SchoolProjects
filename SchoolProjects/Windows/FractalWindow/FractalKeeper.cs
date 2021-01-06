using Fractal;
using Fractal.Fractals;
using FractalWindow.Painter;
using Microsoft.Win32;
using System.IO;
using System.Windows.Media.Imaging;
using Extensions.SystemExt.DrawingExt;
using System.Drawing;
using System.Drawing.Imaging;
using Extensions.MicrosoftExt;
using Fractal.Fractals.LSytemFractals;

namespace FractalWindow
{
    public sealed class FractaKeeper
    {
        private IFractal _fractal;
        private Bitmap _image;

        public void OpenFractalFromJsonFile()
        {
            _fractal = FileExt.OpenFromJsonFileUsingDataContract<Fractal2DByLSystem>(".frac");
        }

        public void SaveFracatlBitmapImage()
        {
            FileExt.SavelBitmapImageToPicturesAsPng(_image);
        }

        public void SaveFracatItemToJsonFile()
        {
            FileExt.SaveJsonToFileUsingDataContract(_fractal, ".frac");
        }

        public BitmapImage OpenFracatlFilee()
        {
            string filePath;
            var openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "C:\\Users\\Work";
            openFileDialog.Filter = ".fractal";
            if (openFileDialog.ShowDialog() == true)
            {
                //Get the path of specified file
                filePath = openFileDialog.FileName;
            }
            var text = File.ReadAllText(openFileDialog.FileName).Split('|');
            return BuildNewFractal(
                startSystemСondition: text[0],
                rotateAngle: text[1],
                generativeRules: text[2],
                systemStepCount: text[3]);
        }

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

            _image = _2DPainter.Draw2DPoints(points);
            return _image.BmpImage();
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
