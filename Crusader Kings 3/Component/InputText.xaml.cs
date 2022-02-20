using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Crusader_Kings_3.Component
{
    /// <summary>
    /// InputText.xaml etkileşim mantığı
    /// </summary>
    public partial class InputText : UserControl
    {


        public string Label {
            get { return (string)GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value);   }
        }
        public static readonly DependencyProperty LabelProperty = DependencyProperty.Register("Label", typeof(string), typeof(InputText), new PropertyMetadata(""));


        public string Value {
            get { return (string)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value);   }
        }
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(string), typeof(InputText), new PropertyMetadata(""));


        public InputText() {
            InitializeComponent();
        }


        public event EventHandler<string> Change;

        private void OnKeyDownHandler(object sender, KeyEventArgs e) {
            if (e.Key == Key.Return) {
                if (Change != null)
                    Change(this, TextNode.Text);
            } 
        }


    }
}
