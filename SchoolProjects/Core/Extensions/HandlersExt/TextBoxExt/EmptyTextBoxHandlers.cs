using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Extensions.HandlersExt.TextBoxExt
{
    public static class EmptyTextBoxHandlers
    {
        private const string HelpPrefix = "like: ";

        public static RoutedEventHandler GetEmptyTextBoxHelpStringLoadedHandler(string text)
        {
            text = HelpPrefix + text;
            return (object sender, RoutedEventArgs e) =>
            {
                TextBox textBox = sender as TextBox;
                textBox.Text = text;
            };
        }
        public static RoutedEventHandler GetEmptyTextBoxHelpStringLostFocusHandler(string text)
        {
            text = HelpPrefix + text;
            return (object sender, RoutedEventArgs e) =>
            {
                TextBox textBox = sender as TextBox;
                if (textBox.Text.Length == 0)
                {
                    textBox.Text = text;
                }
            };
        }
        public static RoutedEventHandler GetEmptyTextBoxHelpStringGetFocusHandler(string text)
        {
            text = HelpPrefix + text;
            return (object sender, RoutedEventArgs e) =>
            {
                TextBox textBox = sender as TextBox;
                if (textBox.Text == text)
                {
                    textBox.Text = string.Empty;
                }
            };
        }
    }
}