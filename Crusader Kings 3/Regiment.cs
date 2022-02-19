using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crusader_Kings_3 {
    public class Regiment : Model {
        public int id{
            get {
                return Memory.getInt(base_address + 0x10);
            }
            set{
                Memory.setInt(base_address + 0x10, value);
            }
        }

        public string name{
            get {
                Int64 pointer = Memory.getInt64(base_address + 0x18);
                return Memory.getText(base_address + 0x18);
            }
            set{ 
                Int64 pointer = Memory.getInt64(base_address + 0x18);
                Memory.setText(base_address + 0x18, value);
            }
        }

        public int refill_progress{
            get {
                return Memory.getInteger8(base_address + 0x38);
            }
            set{
                Memory.setInteger8(base_address + 0x38, value);
            }
        }

        public int max_refill_size{
            get {
                return Memory.getInt(base_address + 0x40);
            }
            set{
                Memory.setInt(base_address + 0x40, value);
            }
        }

        public int cost_prestige_1{
            get {
                return Memory.getInt(base_address + 0x58);
            }
            set{
                Memory.setInt(base_address + 0x58, value);
            }
        }
        
        public int cost_prestige_2{
            get {
                return Memory.getInt(base_address + 0x80);
            }
            set{
                Memory.setInt(base_address + 0x80, value);
            }
        }
    }
}
