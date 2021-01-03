using Extensions.ValidationExt;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Extensions.HandlersExt.TextBoxExt
{
    public static class TextBoxFocuInOutValidationHandlers
    {
        public static RoutedEventHandler TextValidationWithTextColorChanging(Regex regexp, BaseValidation validation)
        {
            return (object sender, RoutedEventArgs e) =>
            {
                TextBox textBox = sender as TextBox;
                if (regexp.IsMatch(textBox.Text))
                {
                    textBox.Background = new SolidColorBrush(Color.FromRgb(226, 225, 225));
                    validation.ChangeControlValidationValue(textBox, true);
                }
                else
                {
                    textBox.Background = new SolidColorBrush(Color.FromRgb(255, 51, 51));
                    validation.ChangeControlValidationValue(textBox, false);
                }
            };
        }
    }
}
