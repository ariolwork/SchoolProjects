using Extensions.HandlersExt.TextBoxExt;
using Extensions.ValidationExt;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace FractalWindow.Handlers.Initializers
{
    public static class HandlersAppliedAtInitStep
    {
        public static void AddEmptyTextBoxInfoMessage<Control>(
            Control control, 
            string message) where Control : FrameworkElement
        {
            control.Loaded += EmptyTextBoxHandlers.GetEmptyTextBoxHelpStringLoadedHandler(message);
            control.LostFocus += EmptyTextBoxHandlers.GetEmptyTextBoxHelpStringLostFocusHandler(message);
            control.GotFocus += EmptyTextBoxHandlers.GetEmptyTextBoxHelpStringGetFocusHandler(message);
        }

        public static void TextBoxColorTextValidation<Control>(
            Control control,
            Regex expr,
            BaseValidation baseValidation) where Control : FrameworkElement
        {
            control.LostFocus += TextBoxFocuInOutValidationHandlers.TextValidationWithTextColorChanging(expr, baseValidation);
        }
    }
}
