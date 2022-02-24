using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Crusader_Kings_3 {
    public class Trait {
        public string id;
        public ImageSource logo; 

        public Trait(string id, ImageSource logo) {
            this.id = id;
            this.logo = logo;
        }
    }
}
