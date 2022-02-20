using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crusader_Kings_3 {
    public class Traits : Model {  
        public int max {
            get {
                return Memory.getInt(base_address + 0x98);
            }
            set {
                Memory.setInt(base_address + 0x98, value);
            }
        }

        public int count {
            get {
                return Memory.getInt(base_address + 0x9C);
            }
            set {
                value = Math.Min(max, Math.Max(value, 0));
                Memory.setInt(base_address + 0x9C, value);
            }
        }

        public int[] list {
            get {
                Int64 pointer = Memory.getInt64(base_address + 0x90);
                byte[] bytes = Memory.getBytes(pointer, count * 0x4);
                int[] traits = new int[count];
                for (int i = 0; i < count; i++)
                    traits[i] = BitConverter.ToInt32(bytes, i * 0x4);

                return traits;
            }
            set {
                Int64 pointer = Memory.getInt64(base_address + 0x90);
                int c = Math.Min(value.Length, max);
                for (int i = 0; i < c; i++)
                    Memory.setInt(pointer + (i * 0x4), value[i]);
                count = c;
            }
        }

        public Traits(Int64 base_address){
            this.base_address = base_address;
        }
    }
}
