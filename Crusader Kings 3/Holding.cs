using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crusader_Kings_3 {
    // this part will be edited later
    public class Holding : Model { 
 
        public string name_id{
            get {
                Int64 pointer = Memory.getInt64(base_address + 0x8);
                return Memory.getText(base_address + 0x18);
            }
            set{
                Int64 pointer = Memory.getInt64(base_address + 0x8);
                Memory.setText(base_address + 0x18, value);
            }
        }
        public string name{
            get {
                Int64 pointer = Memory.getInt64(base_address + 0x8);
                return Memory.getText(base_address + 0x38);
            }
            set{
                Int64 pointer = Memory.getInt64(base_address + 0x8);
                Memory.setText(base_address + 0x38, value);
            }
        }
        public string building_type{
            get {
                Int64 pointer = Memory.getInt64(base_address + 0x68);
                return Memory.getText(base_address + 0x18);
            }
            set{
                Int64 pointer = Memory.getInt64(base_address + 0x68);
                Memory.setText(base_address + 0x18, value);
            }
        }
        public int building_time_left{
            get {
                return Memory.getInteger8(base_address + 0x80);
            }
            set{
                Memory.setInteger8(base_address + 0x80, value);
            }
        }
        public int building_time_scale_factor{
            get {
                return Memory.getInteger8(base_address + 0xB0);
            }
            set{
                Memory.setInteger8(base_address + 0xB0, value);
            }
        }
        public int unknown_time_related_value{
            get {
                return Memory.getInteger8(base_address + 0x138);
            }
            set{
                Memory.setInteger8(base_address + 0x138, value);
            }
        }
        public int barony_title_id{
            get {
                return Memory.getInt(base_address + 0xD8);
            }
            set{
                Memory.setInt(base_address + 0xD8, value);
            }
        }
        public int occupier_id{
            get {
                return Memory.getInt(base_address + 0xDC);
            }
            set{
                Memory.setInt(base_address + 0xDC, value);
            }
        }
        public int owner_id{
            get {
                Int64 pointer = Memory.getInt64(base_address + 0x118);
                return Memory.getInt(pointer + 0x30);
            }
            set{ 
                Int64 pointer = Memory.getInt64(base_address + 0x118);
                Memory.setInt(pointer + 0x30, value);
            }
        }

        
        // this part will be edited later
        public int country;


        public Holding(Int64 base_address) {
            this.base_address = base_address;
        }
    }
}
