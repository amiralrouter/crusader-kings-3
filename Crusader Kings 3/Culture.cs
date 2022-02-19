using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crusader_Kings_3 {
    public class Culture : Model {
        public class Inovation : Model {  
            // this part will be edited later
            public int ID{
                get {
                    return Memory.getInt(base_address + 0x0);
                }
                set{
                    Memory.setInt(base_address + 0x0, value);
                }
            } 
            public string Name { 
                get {
                    Int64 pointer = Memory.getInt64(base_address + 0x10);
                    return Memory.getText(pointer + 0x18);
                }
                set{  
                    Int64 pointer = Memory.getInt64(base_address + 0x10);
                    Memory.setText(pointer + 0x18, value);
                }
            } 
            public int Progress {
                get {
                    return Memory.getInteger8(base_address + 0x18);
                }
                set{
                    Memory.setInteger8(base_address + 0x18, value);
                }
            } 
            public Inovation(Int64 base_address) {
                this.base_address = base_address;
            }
        }
 

        // this part will be edited later
        public List<Inovation> Inventions{
            get{
                List<Inovation> inventions = new List<Inovation>();
                inventions.Add(new Inovation(Memory.getInt64(base_address + 0x10))); 
                return inventions;
            }
        }

        public Culture(Int64 base_address) {
            this.base_address = base_address;
        }
    }
}
