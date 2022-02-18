using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crusader_Kings_3 {
    public class Player {
        public enum GenderType {
            Male, Female
        }
        public enum SexualOrientationType {
            Heterosexual, Homosexual, Bisexual, Asexual, None
        }

        public int Gold {
            get {
                Int64 pointer = Memory.getInt64(baseAddress + 0x138);
                return Memory.getInteger8(pointer + 0x250);
            }
            set {
                Int64 pointer = Memory.getInt64(baseAddress + 0x138);
                Memory.setInteger8(pointer + 0x250, value);
            }
        }
        public int Prestige {
            get {
                Int64 pointer = Memory.getInt64(baseAddress + 0x138);
                return Memory.getInteger8(pointer + 0x100);
            }
            set {
                Int64 pointer = Memory.getInt64(baseAddress + 0x138);
                Memory.setInteger8(pointer + 0x100, value);
            }
        }
        public int Piety {
            get {
                Int64 pointer = Memory.getInt64(baseAddress + 0x138);
                return Memory.getInteger8(pointer + 0xE8);
            }
            set {
                Int64 pointer = Memory.getInt64(baseAddress + 0x138);
                Memory.setInteger8(pointer + 0xE8, value);
            }
        }
        public int Stress {
            get {
                Int64 pointer = Memory.getInt64(baseAddress + 0x138);
                return Memory.getInt(pointer + 0x280);
            }
            set {
                Int64 pointer = Memory.getInt64(baseAddress + 0x138);
                Memory.setInt(pointer + 0x280, value);
            }
        }
        public int Dread {
            get {
                Int64 pointer = Memory.getInt64(baseAddress + 0x148);
                return Memory.getInteger8(pointer + 0x250);
            }
            set {
                Int64 pointer = Memory.getInt64(baseAddress + 0x148);
                Memory.setInteger8(pointer + 0x250, value);
            }
        }



        public int CultureID {
            get {
                return Memory.getInt(baseAddress + 0x78);
            }
            set {
                Memory.setInt(baseAddress + 0x78, value);
            }
        }
        public int FaithID {
            get {
                return Memory.getInt(baseAddress + 0x7C);
            }
            set {
                Memory.setInt(baseAddress + 0x7C, value);
            }
        }
        public int DynastyID {
            get {
                return Memory.getInt(baseAddress + 0xD8);
            }
            set {
                Memory.setInt(baseAddress + 0xD8, value);
            }
        }

        public string BirthDay {
            get {
                return Memory.getInt16(baseAddress + 0x60 + 0x6) + " " + Memory.getByte(baseAddress + 0x60 + 0x5) + " " + Memory.getByte(baseAddress + 0x60 + 0x4);
            }
            set {
            }
        }

        public Int16 Age {
            get {
                return Memory.getInt16(baseAddress + 0x68);
            }
            set {
                Memory.setInt16(baseAddress + 0x68, (Int16)value);
            }
        }
        public Int16 ImmortalAge {
            get {
                return Memory.getInt16(baseAddress + 0x6C);
            }
            set {
                Memory.setInt16(baseAddress + 0x6C, (Int16)value);
            }
        }

        public Int16 BaseWeight {
            get {
                return Memory.getInt16(baseAddress + 0x122);
            }
            set {
                Memory.setInt16(baseAddress + 0x122, (Int16)value);
            }
        }
        public Int16 CurrentWeight {
            get {
                return Memory.getInt16(baseAddress + 0x124);
            }
            set {
                Memory.setInt16(baseAddress + 0x124, (Int16)value);
            }
        }
        public Int16 TargetWeight {
            get {
                return Memory.getInt16(baseAddress + 0x126);
            }
            set {
                Memory.setInt16(baseAddress + 0x126, (Int16)value);
            }
        }

        public GenderType Gender {
            get {
                return (GenderType)Memory.getByte(baseAddress + 0x12C);
            }
            set {
                Memory.setInt(baseAddress + 0x12C, (int)value);
            }
        }
        public SexualOrientationType SexualOrientation {
            get {
                return (SexualOrientationType)Memory.getByte(baseAddress + 0x128);
            }
            set {
                Memory.setInt(baseAddress + 0x128, (int)value);
            }
        }

        public class DNA {
            Player player;
            public string Raw {
                get {
                    Int64 pointer = Memory.getInt64(player.baseAddress + 0xF0);
                    byte[] bytes = Memory.getBytes(pointer, 416);
                    return BitConverter.ToString(bytes).Replace("-", "").Replace("0x", "");
                }
                set {
                    Int64 pointer = Memory.getInt64(player.baseAddress + 0xF0);
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



        // should add offsets
        public class Stats {
            Player player;
            Int64 offset;
            public int Diplomacy {
                get {
                    return Memory.getByte(player.baseAddress + 0x80 + 0x0);
                }
                set {
                    Memory.setByte(player.baseAddress + 0x80 + 0x0, (byte)Utils.HundredLimit(value));
                }
            }
            public int Martial {
                get {
                    return Memory.getByte(player.baseAddress + 0x80 + 0x1);
                }
                set {
                    Memory.setByte(player.baseAddress + 0x80 + 0x1, (byte)Utils.HundredLimit(value));
                }
            }
            public int Stewardship {
                get {
                    return Memory.getByte(player.baseAddress + 0x80 + 0x2);
                }
                set {
                    Memory.setByte(player.baseAddress + 0x80 + 0x2, (byte)Utils.HundredLimit(value));
                }
            }
            public int Intrigue {
                get {
                    return Memory.getByte(player.baseAddress + 0x80 + 0x3);
                }
                set {
                    Memory.setByte(player.baseAddress + 0x80 + 0x3, (byte)Utils.HundredLimit(value));
                }
            }
            public int Learning {
                get {
                    return Memory.getByte(player.baseAddress + 0x80 + 0x4);
                }
                set {
                    Memory.setByte(player.baseAddress + 0x80 + 0x4, (byte)Utils.HundredLimit(value));
                }
            }
            public int Prowess {
                get {
                    return Memory.getByte(player.baseAddress + 0x80 + 0x5);
                }
                set {
                    Memory.setByte(player.baseAddress + 0x80 + 0x5, (byte)Utils.HundredLimit(value));
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
                    return Memory.getInt(player.baseAddress + 0x98);
                }
                set {
                }
            }
            public int Count {
                get {
                    return Memory.getInt(player.baseAddress + 0x9C);
                }
                set {
                    value = Math.Min(Max, Math.Max(value, 0));
                    Memory.setInt(player.baseAddress + 0x9C, value);
                }
            }
            public int[] List {
                get {
                    Int64 pointer = Memory.getInt64(player.baseAddress + 0x90);
                    byte[] bytes = Memory.getBytes(pointer, Count * 0x4);
                    int[] traits = new int[Count];
                    for (int i = 0; i < Count; i++)
                        traits[i] = BitConverter.ToInt32(bytes, i * 0x4);

                    return traits;
                }
                set {
                    Int64 pointer = Memory.getInt64(player.baseAddress + 0x90);
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
                    Int64 pointer = Memory.getInt64(player.baseAddress + 0x138);
                    pointer = Memory.getInt64(pointer + 0x190);
                    return Memory.getInteger8(pointer + 0x8 + (0x10 * 0x0));
                }
                set {
                    Int64 pointer = Memory.getInt64(player.baseAddress + 0x138);
                    pointer = Memory.getInt64(pointer + 0x190);
                    Memory.setInteger8(pointer + 0x8 + (0x10 * 0x0), value);
                }
            }
            public int Martial {
                get {
                    Int64 pointer = Memory.getInt64(player.baseAddress + 0x138);
                    pointer = Memory.getInt64(pointer + 0x190);
                    return Memory.getInteger8(pointer + 0x8 + (0x10 * 0x1));
                }
                set {
                    Int64 pointer = Memory.getInt64(player.baseAddress + 0x138);
                    pointer = Memory.getInt64(pointer + 0x190);
                    Memory.setInteger8(pointer + 0x8 + (0x10 * 0x1), value);
                }
            }
            public int Stewardship {
                get {
                    Int64 pointer = Memory.getInt64(player.baseAddress + 0x138);
                    pointer = Memory.getInt64(pointer + 0x190);
                    return Memory.getInteger8(pointer + 0x8 + (0x10 * 0x2));
                }
                set {
                    Int64 pointer = Memory.getInt64(player.baseAddress + 0x138);
                    pointer = Memory.getInt64(pointer + 0x190);
                    Memory.setInteger8(pointer + 0x8 + (0x10 * 0x2), value);
                }
            }
            public int Intrigue {
                get {
                    Int64 pointer = Memory.getInt64(player.baseAddress + 0x138);
                    pointer = Memory.getInt64(pointer + 0x190);
                    return Memory.getInteger8(pointer + 0x8 + (0x10 * 0x3));
                }
                set {
                    Int64 pointer = Memory.getInt64(player.baseAddress + 0x138);
                    pointer = Memory.getInt64(pointer + 0x190);
                    Memory.setInteger8(pointer + 0x8 + (0x10 * 0x3), value);
                }
            }
            public int Learning {
                get {
                    Int64 pointer = Memory.getInt64(player.baseAddress + 0x138);
                    pointer = Memory.getInt64(pointer + 0x190);
                    return Memory.getInteger8(pointer + 0x8 + (0x10 * 0x4));
                }
                set {
                    Int64 pointer = Memory.getInt64(player.baseAddress + 0x138);
                    pointer = Memory.getInt64(pointer + 0x190);
                    Memory.setInteger8(pointer + 0x8 + (0x10 * 0x4), value);
                }
            }

            public Lifestyle(Player player) {
                this.player = player;
            }
        }

        public Int64 baseAddress;
    }
}
