using FractalWindow.Handlers.Initializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public FractalWindowEvents()
        {
            InitializeComponent();
            InitEmptyTextBoxHelpValues();
        }
        
        public void InitEmptyTextBoxHelpValues()
        {
            new List<KeyValuePair<Control, string>>()
            {
                new KeyValuePair<Control, string>(this.SystemStartString, "F+F+F"),
                new KeyValuePair<Control, string>(this.SystemRulestring, $"F=F+F{Environment.NewLine}       F+=F")
            }.ForEach(pair => HandlersAppliedAtInitStep.AddEmptyTextBoxInfoMessage(pair.Key, pair.Value));
        }
    }
}
