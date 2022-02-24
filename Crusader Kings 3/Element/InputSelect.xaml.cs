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

namespace Crusader_Kings_3.Element { 
    public partial class InputSelect : UserControl {

        public string Label {
            get { return (string)GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value); }
        }
        public static readonly DependencyProperty LabelProperty = DependencyProperty.Register("Label", typeof(string), typeof(InputSelect), new PropertyMetadata(""));


        public string Value {
            get { return (string)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(string), typeof(InputSelect), new PropertyMetadata(""));


        public InputSelect() {
            InitializeComponent();
        }


        public event EventHandler<string> Change;

        private void OnKeyDownHandler(object sender, KeyEventArgs e) {
            //if (e.Key == Key.Return) {
            //    if (Change != null)
            //        Change(this, TextNode.Text);
            //}
        }

    }
}
