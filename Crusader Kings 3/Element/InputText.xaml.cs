using System; 
using System.Windows;
using System.Windows.Controls; 
using System.Windows.Input; 

namespace Crusader_Kings_3.Element {
    public partial class InputText : UserControl {
        public string Label {
            get { return (string)GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value); }
        }
        public static readonly DependencyProperty LabelProperty = DependencyProperty.Register("Label", typeof(string), typeof(InputText), new PropertyMetadata(""));


        public string Value {
            get { return (string)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(string), typeof(InputText), new PropertyMetadata(""));


        public InputText() {
            InitializeComponent();
        }


        public event EventHandler<string> Change;
        public event EventHandler<string> Input;

        private void OnKeyDownHandler(object sender, KeyEventArgs e) {
            if (Input != null)
                Input(this, TextNode.Text);
            if (e.Key == Key.Return) {
                if (Change != null)
                    Change(this, TextNode.Text);
            }
        }
    }
}
