using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crusader_Kings_3 {
    public class Faith : Model { 

        public class Doctrine: Model{ 
            public int id{
                get {
                    return Memory.getInt(base_address + 0x8);
                }
            } 
            public string name { 
                get {
                    return Memory.getText(base_address + 0xC0);
                }
                set{ 
                    Memory.setText(base_address + 0xC0, value);
                }
            } 
            public Doctrine(Int64 base_address) {
                this.base_address = base_address;
            }
        }
 

        public int id{
            get {
                return Memory.getInt(base_address + 0x8);
            }
        }

        public string name { 
            get {
                return Memory.getText(base_address + 0xC0);
            }
            set{ 
                Memory.setText(base_address + 0xC0, value);
            }
        }
        public int fervor { 
            get {
                return Memory.getInteger8(base_address + 0x250);
            }
            set{  
                Memory.setInteger8(base_address + 0x250, value);
            }
        }

        public int founder_id{
            get {
                return Memory.getInt(base_address + 0x25C);
            }
            set{
                Memory.setInt(base_address + 0x25C, value);
            }
        }
        public int religious_head_id{
            get {
                return Memory.getInt(base_address + 0x258);
            }
            set{
                Memory.setInt(base_address + 0x258, value);
            }
        }
        public int religion_id{
            get {
                return Memory.getInt(base_address + 0x338);
            }
            set{
                Memory.setInt(base_address + 0x338, value);
            }
        }

        
        public List<Doctrines> doctrines;


        public Faith(Int64 base_address) {
            this.base_address = base_address;
        }

        public override void OnBaseAddressChanged(){

            // this part will be edited later
            doctrines = new List<Doctrines>();
            foreach (var d in Memory.getArray(base_address + 0x1C0, 0x10)) {
                doctrines.Add(new Doctrines(d));
            }
        }
    }
}
