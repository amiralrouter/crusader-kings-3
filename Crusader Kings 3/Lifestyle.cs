using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crusader_Kings_3 {
    public class Lifestyle : Model {
        public int Diplomacy {
            get {
                Int64 pointer = Memory.getInt64(base_address + 0x138);
                pointer = Memory.getInt64(pointer + 0x190);
                return Memory.getInteger8(pointer + 0x8 + (0x10 * 0x0));
            }
            set {
                Int64 pointer = Memory.getInt64(base_address + 0x138);
                pointer = Memory.getInt64(pointer + 0x190);
                Memory.setInteger8(pointer + 0x8 + (0x10 * 0x0), value);
            }
        }
        public int Martial {
            get {
                Int64 pointer = Memory.getInt64(base_address + 0x138);
                pointer = Memory.getInt64(pointer + 0x190);
                return Memory.getInteger8(pointer + 0x8 + (0x10 * 0x1));
            }
            set {
                Int64 pointer = Memory.getInt64(base_address + 0x138);
                pointer = Memory.getInt64(pointer + 0x190);
                Memory.setInteger8(pointer + 0x8 + (0x10 * 0x1), value);
            }
        }
        public int Stewardship {
            get {
                Int64 pointer = Memory.getInt64(base_address + 0x138);
                pointer = Memory.getInt64(pointer + 0x190);
                return Memory.getInteger8(pointer + 0x8 + (0x10 * 0x2));
            }
            set {
                Int64 pointer = Memory.getInt64(base_address + 0x138);
                pointer = Memory.getInt64(pointer + 0x190);
                Memory.setInteger8(pointer + 0x8 + (0x10 * 0x2), value);
            }
        }
        public int Intrigue {
            get {
                Int64 pointer = Memory.getInt64(base_address + 0x138);
                pointer = Memory.getInt64(pointer + 0x190);
                return Memory.getInteger8(pointer + 0x8 + (0x10 * 0x3));
            }
            set {
                Int64 pointer = Memory.getInt64(base_address + 0x138);
                pointer = Memory.getInt64(pointer + 0x190);
                Memory.setInteger8(pointer + 0x8 + (0x10 * 0x3), value);
            }
        }
        public int Learning {
            get {
                Int64 pointer = Memory.getInt64(base_address + 0x138);
                pointer = Memory.getInt64(pointer + 0x190);
                return Memory.getInteger8(pointer + 0x8 + (0x10 * 0x4));
            }
            set {
                Int64 pointer = Memory.getInt64(base_address + 0x138);
                pointer = Memory.getInt64(pointer + 0x190);
                Memory.setInteger8(pointer + 0x8 + (0x10 * 0x4), value);
            }
        }
        public Lifestyle(Int64 base_address) {
            this.base_address = base_address;
        }
    }
}
