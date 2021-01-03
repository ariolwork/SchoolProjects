using Extensions.ValidationExt;
using Fractal;
using FractalWindow.Handlers.Initializers;
using FractalWindow.Painter;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FractalWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class FractalWindowEvents : Window
    {
        BaseValidation _baseValidation = new BaseValidation();

        public FractalWindowEvents()
        {
            InitializeComponent();
            InitHandlers();
        }

        public void InitHandlers()
        {
            InitEmptyTextBoxHelpValues();
            InitTextBoxValidationHandler();
        }

        public void InitTextBoxValidationHandler()
        {
            new List<KeyValuePair<Control, Regex>>()
            {
                new KeyValuePair<Control, Regex>(this.RotateAngle, new Regex(@"^\d{1,3}$")),
                new KeyValuePair<Control, Regex>(this.SystemRulestring, new Regex(@"(^[\w\s+-_]+[=][\w\s+-_]+$)+"))
            }.ForEach(pair => HandlersAppliedAtInitStep.TextBoxColorTextValidation(pair.Key, pair.Value, _baseValidation));
        }


        public void InitEmptyTextBoxHelpValues()
        {
            new List<KeyValuePair<Control, string>>()
            {
                new KeyValuePair<Control, string>(this.SystemStartString, "F+F+F"),
                new KeyValuePair<Control, string>(this.SystemRulestring, $"F=F+F{Environment.NewLine}       F+=F")
            }.ForEach(pair => HandlersAppliedAtInitStep.AddEmptyTextBoxInfoMessage(pair.Key, pair.Value));
        }

        private void DrawFractal_Click(object sender, RoutedEventArgs e)
        {
            var fractal = FractalBuilder.Get2DLSystemFractal(
                startSystemСondition: SystemStartString.Text,
                rotateAngle: int.Parse(RotateAngle.Text),
                generativeRules: SystemRulestring.Text);
            var points = fractal.Points(
                stepCount: int.Parse(SystemStepCount.Text));
            var bitmap = _2DPainter.Draw2DPoints(points);
            FractalImagePanel.Source = bitmap;
        }
    }
}
