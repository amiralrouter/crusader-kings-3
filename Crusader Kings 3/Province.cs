using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crusader_Kings_3 {
    public class Province : Model {

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
                Int64 pointer = Memory.getInt64(base_address + 0x8);
                return Memory.getText(base_address + 0x28);
            }
            set{
                Int64 pointer = Memory.getInt64(base_address + 0x8);
                Memory.setText(base_address + 0x28, value);
            }
        }

        public Holding holding;

        public Province(Int64 base_address) {
            this.base_address = base_address;
            holding = new Holding(Memory.getInt64(base_address + 0x40));
        }
 
        public override void OnBaseAddressChanged() {
            base.OnBaseAddressChanged(); 
            
            holding = new Holding(Memory.getInt64(base_address + 0x280));
        }
    }
}
