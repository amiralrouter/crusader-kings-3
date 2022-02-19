using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crusader_Kings_3 {
    public class Army : Model {

        public int id{
            get {
                return Memory.getInt(base_address + 0x10);
            }
            set{
                Memory.setInt(base_address + 0x10, value);
            }
        }

        // this part will be edited later
        public string source_army_province_name{
            get {
                // Int64 pointer = Memory.getInt64(base_address + 0x8);
                return Memory.getText(base_address + 0x28);
            }
            set{
                // Int64 pointer = Memory.getInt64(base_address + 0x8);
                // Memory.setText(base_address + 0x28, value);
            }
        }

        public int commander_id{
            get {
                return Memory.getInt(base_address + 0xE8);
            }
            set{
                Memory.setInt(base_address + 0xE8, value);
            }
        }
        
        public int owner_id{
            get {
                return Memory.getInt(base_address + 0xC0);
            }
            set{
                Memory.setInt(base_address + 0xC0, value);
            }
        }

        public int unit_id{
            get {
                return Memory.getInt(base_address + 0xEC);
            }
            set{
                Memory.setInt(base_address + 0xEC, value);
            }
        }

        public int cost_gold{
            get {
                return Memory.getInt(base_address + 0x100);
            }
            set{
                Memory.setInt(base_address + 0x100, value);
            }
        }

        public int cost_prestige{
            get {
                return Memory.getInt(base_address + 0x108);
            }
            set{
                Memory.setInt(base_address + 0x108, value);
            }
        }

        public int supply{
            get {
                return Memory.getInteger8(base_address + 0x120);
            }
            set{
                Memory.setInteger8(base_address + 0x120, value);
            }
        }

        public int last_supply_date{
            get {
                return Memory.getDate(base_address + 0x128);
            }
            set{
                Memory.setDate(base_address + 0x128, value);
            }
        }

        public int gathered_date{
            get {
                return Memory.getDate(base_address + 0x130);
            }
            set{
                Memory.setDate(base_address + 0x130, value);
            }
        }


        public List<Regiments> regiments = new List<Regiments>();


        public Army(Int64 base_address) {
            this.base_address = base_address;

            regiments.Clear();
        }

    }
}
