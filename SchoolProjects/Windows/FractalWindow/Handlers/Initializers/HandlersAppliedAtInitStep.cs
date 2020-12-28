using Extensions.HandlersExt.TextBoxExt;
using System;
using System.Collections.Generic;
using System.Text;
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
    }
}
