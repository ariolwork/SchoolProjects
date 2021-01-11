using Extensions.HandlersExt.TextBoxExt;
using Extensions.ValidationExt;
using QueenProblemWindow.Modifiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace QueenProblemWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BaseValidation _baseValidation = new BaseValidation();
        ImageCycleKeeper imageKeeper;

        public MainWindow()
        {
            InitializeComponent();
            InitHandlers();
        }

        public void InitHandlers()
        {
            InitTextBoxValidationHandler();
        }

        public void InitTextBoxValidationHandler()
        {
            new List<KeyValuePair<Control, Regex>>()
            {
                new KeyValuePair<Control, Regex>(this.BorderSize, new Regex(@"^\d{1,3}$"))
            }.ForEach(pair => TextBoxColorTextValidation(pair.Key, pair.Value, _baseValidation));
        }

        private void SolveButton_Click(object sender, RoutedEventArgs e)
        {
            if (_baseValidation.GetFullValidationStatus())
            {
                int borderSize = int.Parse(this.BorderSize.Text);
                var solve = QueenProblem.QueenProblem.SolveProblem(borderSize);
                Points.Text = $"Solutions count: {solve.Count}{Environment.NewLine}" + TextFormatter.FormatPointListIntoString(solve);
                if (solve.Count() != 0) {
                    imageKeeper = new ImageCycleKeeper(_2DPainter.Draw2DChessAreas(solve, borderSize, 400, 400));
                    BorderImage.Source = imageKeeper.GetCurrent();
                }
            }
        }

        private static void TextBoxColorTextValidation<Control>(
            Control control,
            Regex expr,
            BaseValidation baseValidation) where Control : FrameworkElement
        {
            control.LostFocus += TextBoxFocuInOutValidationHandlers.TextValidationWithTextColorChanging(expr, baseValidation);
        }

        private void NextImage_Click(object sender, RoutedEventArgs e)
        {
            BorderImage.Source = imageKeeper.GetNext();
        }

        private void PrevImage_Click(object sender, RoutedEventArgs e)
        {
            BorderImage.Source = imageKeeper.GetPrevious();
        }
    }
}
