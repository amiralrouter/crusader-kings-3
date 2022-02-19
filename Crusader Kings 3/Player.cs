using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crusader_Kings_3 {
    public class Player : Model {
        public enum Gender {
            Male, Female
        }
        public enum SexualOrientation {
            Heterosexual, Homosexual, Bisexual, Asexual, None
        }

        public class DNA {
            Player player;
            public string Raw {
                get {
                    Int64 pointer = Memory.getInt64(player.base_address + 0xF0);
                    byte[] bytes = Memory.getBytes(pointer, 416);
                    return BitConverter.ToString(bytes).Replace("-", "").Replace("0x", "");
                }
                set {
                    Int64 pointer = Memory.getInt64(player.base_address + 0xF0);
                    byte[] bytes = new byte[416];
                    for (int i = 0; i < value.Length; i += 2) {
                        bytes[i / 2] = Convert.ToByte(value.Substring(i, 2), 16);
                    }
                    Memory.setBytes(pointer, bytes);
                }
            }
            public DNA(Player player) {
                this.player = player;
            }
        }
         
        public class Stats {
            Player player;
            Int64 offset;
            public int Diplomacy {
                get {
                    return Memory.getByte(player.base_address + offset + 0x0);
                }
                set {
                    Memory.setByte(player.base_address + offset + 0x0, (byte)Utils.HundredLimit(value));
                }
            }
            public int Martial {
                get {
                    return Memory.getByte(player.base_address + offset + 0x1);
                }
                set {
                    Memory.setByte(player.base_address + offset + 0x1, (byte)Utils.HundredLimit(value));
                }
            }
            public int Stewardship {
                get {
                    return Memory.getByte(player.base_address + offset + 0x2);
                }
                set {
                    Memory.setByte(player.base_address + offset + 0x2, (byte)Utils.HundredLimit(value));
                }
            }
            public int Intrigue {
                get {
                    return Memory.getByte(player.base_address + offset + 0x3);
                }
                set {
                    Memory.setByte(player.base_address + offset + 0x3, (byte)Utils.HundredLimit(value));
                }
            }
            public int Learning {
                get {
                    return Memory.getByte(player.base_address + offset + 0x4);
                }
                set {
                    Memory.setByte(player.base_address + offset + 0x4, (byte)Utils.HundredLimit(value));
                }
            }
            public int Prowess {
                get {
                    return Memory.getByte(player.base_address + offset + 0x5);
                }
                set {
                    Memory.setByte(player.base_address + offset + 0x5, (byte)Utils.HundredLimit(value));
                }
            }

            public Stats(Player player, Int64 offset) {
                this.player = player;
                this.offset = offset;
            }
        }

        public class Traits {
            Player player;
            public int Max {
                get {
                    return Memory.getInt(player.base_address + 0x98);
                }
                set {
                    Memory.setInt(player.base_address + 0x98, value);
                }
            }
            public int Count {
                get {
                    return Memory.getInt(player.base_address + 0x9C);
                }
                set {
                    value = Math.Min(Max, Math.Max(value, 0));
                    Memory.setInt(player.base_address + 0x9C, value);
                }
            }
            public int[] List {
                get {
                    Int64 pointer = Memory.getInt64(player.base_address + 0x90);
                    byte[] bytes = Memory.getBytes(pointer, Count * 0x4);
                    int[] traits = new int[Count];
                    for (int i = 0; i < Count; i++)
                        traits[i] = BitConverter.ToInt32(bytes, i * 0x4);

                    return traits;
                }
                set {
                    Int64 pointer = Memory.getInt64(player.base_address + 0x90);
                    int count = Math.Min(value.Length, Max);
                    for (int i = 0; i < count; i++)
                        Memory.setInt(pointer + (i * 0x4), value[i]);
                    Count = count;
                }
            }
            public Traits(Player player) {
                this.player = player;
            }
        }

        public class Lifestyle {
            Player player;
            public int Diplomacy {
                get {
                    Int64 pointer = Memory.getInt64(player.base_address + 0x138);
                    pointer = Memory.getInt64(pointer + 0x190);
                    return Memory.getInteger8(pointer + 0x8 + (0x10 * 0x0));
                }
                set {
                    Int64 pointer = Memory.getInt64(player.base_address + 0x138);
                    pointer = Memory.getInt64(pointer + 0x190);
                    Memory.setInteger8(pointer + 0x8 + (0x10 * 0x0), value);
                }
            }
            public int Martial {
                get {
                    Int64 pointer = Memory.getInt64(player.base_address + 0x138);
                    pointer = Memory.getInt64(pointer + 0x190);
                    return Memory.getInteger8(pointer + 0x8 + (0x10 * 0x1));
                }
                set {
                    Int64 pointer = Memory.getInt64(player.base_address + 0x138);
                    pointer = Memory.getInt64(pointer + 0x190);
                    Memory.setInteger8(pointer + 0x8 + (0x10 * 0x1), value);
                }
            }
            public int Stewardship {
                get {
                    Int64 pointer = Memory.getInt64(player.base_address + 0x138);
                    pointer = Memory.getInt64(pointer + 0x190);
                    return Memory.getInteger8(pointer + 0x8 + (0x10 * 0x2));
                }
                set {
                    Int64 pointer = Memory.getInt64(player.base_address + 0x138);
                    pointer = Memory.getInt64(pointer + 0x190);
                    Memory.setInteger8(pointer + 0x8 + (0x10 * 0x2), value);
                }
            }
            public int Intrigue {
                get {
                    Int64 pointer = Memory.getInt64(player.base_address + 0x138);
                    pointer = Memory.getInt64(pointer + 0x190);
                    return Memory.getInteger8(pointer + 0x8 + (0x10 * 0x3));
                }
                set {
                    Int64 pointer = Memory.getInt64(player.base_address + 0x138);
                    pointer = Memory.getInt64(pointer + 0x190);
                    Memory.setInteger8(pointer + 0x8 + (0x10 * 0x3), value);
                }
            }
            public int Learning {
                get {
                    Int64 pointer = Memory.getInt64(player.base_address + 0x138);
                    pointer = Memory.getInt64(pointer + 0x190);
                    return Memory.getInteger8(pointer + 0x8 + (0x10 * 0x4));
                }
                set {
                    Int64 pointer = Memory.getInt64(player.base_address + 0x138);
                    pointer = Memory.getInt64(pointer + 0x190);
                    Memory.setInteger8(pointer + 0x8 + (0x10 * 0x4), value);
                }
            }

            public Lifestyle(Player player) {
                this.player = player;
            }
        }

 

        public int id {
            get {
                return Memory.getInt(base_address + 0x30);
            }
            set { 
                Memory.setInt(base_address + 0x30, value);
            }
        }

        public string name {
            get {
                return Memory.getText(base_address + 0x20); 
            }
            set {  
                Memory.setText(base_address + 0x20, value);
            }
        }

        public int gold {
            get {
                Int64 pointer = Memory.getInt64(base_address + 0x138);
                return Memory.getInteger8(pointer + 0x250);
            }
            set {
                Int64 pointer = Memory.getInt64(base_address + 0x138);
                Memory.setInteger8(pointer + 0x250, value);
            }
        }
        public int prestige {
            get {
                Int64 pointer = Memory.getInt64(base_address + 0x138);
                return Memory.getInteger8(pointer + 0x100);
            }
            set {
                Int64 pointer = Memory.getInt64(base_address + 0x138);
                Memory.setInteger8(pointer + 0x100, value);
            }
        }
        public int piety {
            get {
                Int64 pointer = Memory.getInt64(base_address + 0x138);
                return Memory.getInteger8(pointer + 0xE8);
            }
            set {
                Int64 pointer = Memory.getInt64(base_address + 0x138);
                Memory.setInteger8(pointer + 0xE8, value);
            }
        }
        public int stress {
            get {
                Int64 pointer = Memory.getInt64(base_address + 0x138);
                return Memory.getInt(pointer + 0x280);
            }
            set {
                Int64 pointer = Memory.getInt64(base_address + 0x138);
                Memory.setInt(pointer + 0x280, value);
            }
        }
        public int dread {
            get {
                Int64 pointer = Memory.getInt64(base_address + 0x148);
                return Memory.getInteger8(pointer + 0x250);
            }
            set {
                Int64 pointer = Memory.getInt64(base_address + 0x148);
                Memory.setInteger8(pointer + 0x250, value);
            }
        }

        
        public int culture_id {
            get {
                return Memory.getInt(base_address + 0x78);
            }
            set {
                Memory.setInt(base_address + 0x78, value);
            }
        }
        public int faith_id {
            get {
                return Memory.getInt(base_address + 0x7C);
            }
            set {
                Memory.setInt(base_address + 0x7C, value);
            }
        }
        public int dynasty_id {
            get {
                return Memory.getInt(base_address + 0xD8);
            }
            set {
                Memory.setInt(base_address + 0xD8, value);
            }
        }

        public string birth_date {
            get {
                return Memory.getInt16(base_address + 0x60 + 0x6) + " " + Memory.getByte(base_address + 0x60 + 0x5) + " " + Memory.getByte(base_address + 0x60 + 0x4);
            }
            set {
            }
        }

        public Int16 age {
            get {
                return Memory.getInt16(base_address + 0x68);
            }
            set {
                Memory.setInt16(base_address + 0x68, (Int16)value);
            }
        }
        public Int16 immortal_age {
            get {
                return Memory.getInt16(base_address + 0x6C);
            }
            set {
                Memory.setInt16(base_address + 0x6C, (Int16)value);
            }
        }

        public Int16 base_weight {
            get {
                return Memory.getInt16(base_address + 0x122);
            }
            set {
                Memory.setInt16(base_address + 0x122, (Int16)value);
            }
        }
        public Int16 current_weight {
            get {
                return Memory.getInt16(base_address + 0x124);
            }
            set {
                Memory.setInt16(base_address + 0x124, (Int16)value);
            }
        }
        public Int16 target_weight {
            get {
                return Memory.getInt16(base_address + 0x126);
            }
            set {
                Memory.setInt16(base_address + 0x126, (Int16)value);
            }
        }

        public Gender gender {
            get {
                return (Gender)Memory.getByte(base_address + 0x12C);
            }
            set {
                Memory.setInt(base_address + 0x12C, (int)value);
            }
        }
        public SexualOrientation sexual_orientation {
            get {
                return (SexualOrientation)Memory.getByte(base_address + 0x128);
            }
            set {
                Memory.setInt(base_address + 0x128, (int)value);
            }
        }
         
        public Stats base_stats;
        public Stats modified_stats; 
        public DNA dna;
        public Traits traits;
        public Lifestyle lifestyle;

        public Player() { 
            base_stats = new Stats(this, 0x80);
            modified_stats = new Stats(this, 0x86); 
            dna = new DNA(this);
            traits = new Traits(this);
            lifestyle = new Lifestyle(this);
        }
    }
}
