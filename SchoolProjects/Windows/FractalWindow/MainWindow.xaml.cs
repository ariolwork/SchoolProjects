using Extensions.ValidationExt;
using Fractal;
using FractalWindow.Handlers.Initializers;
using FractalWindow.Painter;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace FractalWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class FractalWindowEvents : Window
    {
        BaseValidation _baseValidation = new BaseValidation();
        FractaKeeper _fractaKeeper = new FractaKeeper();

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
            var bitmap = _fractaKeeper.BuildNewFractal(
                startSystemСondition: SystemStartString.Text,
                rotateAngle: RotateAngle.Text,
                generativeRules: SystemRulestring.Text,
                systemStepCount: SystemStepCount.Text);
            FractalImagePanel.Source = bitmap;
        }

        private void SaveImageButton_Click(object sender, RoutedEventArgs e)
        {
            _fractaKeeper.SaveFracatlBitmapImage();
        }

        private void SaveAsFileButton_Click(object sender, RoutedEventArgs e)
        {
            _fractaKeeper.SaveFracatItemToJsonFile();
        }
    }
}
