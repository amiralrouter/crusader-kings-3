using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crusader_Kings_3 {
    public class Focus : Model {

        public string type {
            get {
                Int64 pointer = Memory.getInt64(base_address + 0x8); 
                return Memory.getText(pointer + 0x18);
            }
            set { 
                Int64 pointer = Memory.getInt64(base_address + 0x8);
                Memory.setText(pointer + 0x18, value);
            }
        }

        public string start_date {
            get {
                return Memory.getDate(base_address + 0x10);
            }
            set {
                Memory.setDate(base_address + 0x10, value);
            }
        }

        public string end_date {
            get {
                return Memory.getDate(base_address + 0x14);
            }
            set {
                Memory.setDate(base_address + 0x14, value);
            }
        }

        public int changes {
            get {
                return Memory.getInt(base_address + 0x18);
            }
            set {
                Memory.setInt(base_address + 0x18, value);
            }
        }

        public int progress {
            get {
                return Memory.getInt(base_address + 0x1C);
            }
            set {
                Memory.setInt(base_address + 0x1C, value);
            }
        }


        public Focus(Int64 base_address) {
            this.base_address = base_address;
        }

    }
}
