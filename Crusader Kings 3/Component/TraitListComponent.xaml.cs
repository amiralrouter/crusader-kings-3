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

namespace Crusader_Kings_3.Component {
    /// <summary>
    /// TraitListComponent.xaml etkileşim mantığı
    /// </summary>
    public partial class TraitListComponent : UserControl {


        public string Items {
            get { return (string)GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value); }
        }
        public static readonly DependencyProperty LabelProperty = DependencyProperty.Register("Label", typeof(string), typeof(InputText), new PropertyMetadata(""));





        public TraitListComponent() {
            InitializeComponent();
        }
    }
}
