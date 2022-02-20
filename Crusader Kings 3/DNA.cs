using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crusader_Kings_3 {
    public class DNA : Model {

 
        public byte[] bytes {
            get { 
                Int64 pointer = Memory.getInt64(base_address + 0xF0);
                return Memory.getBytes(pointer, 416);
            }
            set {
                Memory.setBytes(base_address, value);
            }
        }

        public string hex {
            get { 
                return BitConverter.ToString(this.bytes).Replace("-", "").Replace("0x", "");
            }
            set { 
                byte[] bytes = new byte[416];
                for (int i = 0; i < value.Length; i += 2)  
                    bytes[i / 2] = Convert.ToByte(value.Substring(i, 2), 16); 
                this.bytes = bytes; 
            }
        }


        public DNA(Int64 base_address) {
            this.base_address = base_address;
        }

        private int hair_color_offset = 0;
        public int hair_color{
            get{ 
                return BitConverter.ToInt32(bytes, hair_color_offset); 
            }
            set{ 
                bytes[hair_color_offset + 0x0] = (byte)(value & 0xFF);
                bytes[hair_color_offset + 0x1] = (byte)((value >> 8) & 0xFF);
                bytes[hair_color_offset + 0x2] = (byte)((value >> 16) & 0xFF);
                bytes[hair_color_offset + 0x3] = (byte)((value >> 24) & 0xFF);
                Memory.setInt(base_address + hair_color_offset, value);
            }
        }

    }
}
