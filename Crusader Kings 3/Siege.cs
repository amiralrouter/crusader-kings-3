using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crusader_Kings_3 {
    public class Siege : Model {
 
        
        public int id{
            get {
                return Memory.getInt(base_address + 0x8);
            }
        }
        public int morale1{
            get {
                return Memory.getInteger8(base_address + 0x30);
            }
            set{  
                Memory.setInteger8(base_address + 0x30, value);
            }
        }
        public int morale2{
            get {
                return Memory.getInteger8(base_address + 0x50);
            }
            set{  
                Memory.setInteger8(base_address + 0x50, value);
            }
        }

        public int army_id{
            get {
                return Memory.getInt(base_address + 0x48);
            }
            set{
                Memory.setInt(base_address + 0x48, value);
            }
        }
        // <summary>
        //  Siege Phase Time
        //  (count up to 20)
        // </summary>
        public int siege_phase_time {
            get {
                return Memory.getInt(base_address + 0xBC);
            }
            set{
                Memory.setInt(base_address + 0xBC, value);
            }
        }

        public int random_seed {
            get {
                return Memory.getInt(base_address + 0xC0);
            }
            set{
                Memory.setInt(base_address + 0xC0, value);
            }
        }

        // this part will be edited later
        public string start_date {
            get {
                return "";
            }
            set{ 
            }
        }

        public Province province;

        public override void OnBaseAddressChanged() {
            base.OnBaseAddressChanged(); 
            province = new Province(Memory.getInt64(base_address + 0x40));
        }


    }
}
