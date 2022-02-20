using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crusader_Kings_3 {
    public class Stats : Model {
        Int64 offset;
        public int diplomacy {
            get {
                return Memory.getByte(base_address + offset + 0x0);
            }
            set {
                Memory.setByte(base_address + offset + 0x0, (byte)Utils.HundredLimit(value));
            }
        }
        public int martial {
            get {
                return Memory.getByte(base_address + offset + 0x1);
            }
            set {
                Memory.setByte(base_address + offset + 0x1, (byte)Utils.HundredLimit(value));
            }
        }
        public int stewardship {
            get {
                return Memory.getByte(base_address + offset + 0x2);
            }
            set {
                Memory.setByte(base_address + offset + 0x2, (byte)Utils.HundredLimit(value));
            }
        }
        public int intrigue {
            get {
                return Memory.getByte(base_address + offset + 0x3);
            }
            set {
                Memory.setByte(base_address + offset + 0x3, (byte)Utils.HundredLimit(value));
            }
        }
        public int learning {
            get {
                return Memory.getByte(base_address + offset + 0x4);
            }
            set {
                Memory.setByte(base_address + offset + 0x4, (byte)Utils.HundredLimit(value));
            }
        }
        public int prowess {
            get {
                return Memory.getByte(base_address + offset + 0x5);
            }
            set {
                Memory.setByte(base_address + offset + 0x5, (byte)Utils.HundredLimit(value));
            }
        }

        public Stats(Int64 base_address, Int64 offset) {
            this.base_address = base_address;
            this.offset = offset;
        }
    }
}
