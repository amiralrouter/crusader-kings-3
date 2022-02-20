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
        public int fertility {
            get {
                Int64 pointer = Memory.getInt64(base_address + 0x138);
                return Memory.getInteger4(pointer + 0x268);
            }
            set { 
                Int64 pointer = Memory.getInt64(base_address + 0x138);
                Memory.setInteger4(pointer + 0x268, value);
            }
        }
        public int max_fertility {
            get {
                Int64 pointer = Memory.getInt64(base_address + 0x138);
                return Memory.getInteger4(pointer + 0x308);
            }
            set { 
                Int64 pointer = Memory.getInt64(base_address + 0x138);
                Memory.setInteger4(pointer + 0x308, value);
            }
        }
        public int health {
            get {
                Int64 pointer = Memory.getInt64(base_address + 0x138);
                return Memory.getInteger8(pointer + 0x278);
            }
            set { 
                Int64 pointer = Memory.getInt64(base_address + 0x138);
                Memory.setInteger8(pointer + 0x278, value);
            }
        }
        public int max_health {
            get {
                Int64 pointer = Memory.getInt64(base_address + 0x138);
                return Memory.getInteger8(pointer + 0x310);
            }
            set { 
                Int64 pointer = Memory.getInt64(base_address + 0x138);
                Memory.setInteger8(pointer + 0x310, value);
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
        public Lifestyle lifestyle;
        public Focus focus;
        public Traits traits;

        public Player() { 
            base_stats = new Stats(base_address, 0x80);
            modified_stats = new Stats(base_address, 0x86); 
            dna = new DNA(base_address);
            lifestyle = new Lifestyle(base_address);
            focus = new Focus(Memory.getInt64(Memory.getInt64(base_address + 0x138) + 0x218));
            traits = new Traits(base_address);
        }

        public override void OnBaseAddressChanged(){
            base_stats = new Stats(base_address, 0x80);
            modified_stats = new Stats(base_address, 0x86); 
            dna = new DNA(base_address);
            lifestyle = new Lifestyle(base_address);
            focus = new Focus(Memory.getInt64(Memory.getInt64(base_address + 0x138) + 0x218));
            traits = new Traits(base_address);
        }
    }
}
