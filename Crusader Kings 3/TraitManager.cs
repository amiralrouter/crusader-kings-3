using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Crusader_Kings_3 {
    public static class TraitManager {
        public class TraitObject {
            public string id;
            public ImageSource logo;

            public TraitObject(string id, ImageSource logo) {
                this.id = id;
                this.logo = logo;
            }
        }


        public static List<TraitObject> list = new List<TraitObject>(); 

        public static List<TraitObject> GetList() {
            if(list.Count == 0) {
                string[] trait_ids = Properties.Resources.trait_ids.Split('\n');
                foreach (string trait_id in trait_ids) {
                    if (trait_id.Length < 1) continue; 

                    Bitmap bmp = Properties.Resources.ResourceManager.GetObject(trait_id) as Bitmap;
    
                    ImageSource img = Utils.BitmapToImageSource(bmp);
                    list.Add(new TraitObject(trait_id, img));
                }
            } 
            return list;
        }
    }
}
