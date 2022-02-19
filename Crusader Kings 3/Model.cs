using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crusader_Kings_3 {
    public class Model {

        private Int64 _base_address;

        public Int64 base_address {
            get {
                return _base_address;
            }
            set {
                _base_address = value;
                OnBaseAddressChanged();
                province = new Province(Memory.getInt64(base_address + 0x40));
            }
        }

        public void OnBaseAddressChanged(){

        }

    }
}
