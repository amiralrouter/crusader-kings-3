using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crusader_Kings_3 {
    static class Utils {

        // return string in bytes until null byte
        public static string GetString(byte[] buffer) {
            int stringLength = buffer.TakeWhile(b => b != 0).Count();
            return Encoding.UTF8.GetString(buffer, 0, stringLength);
        }


        // return value min 0 max 100
        public static int HundredLimit(int value) {
            return Math.Min(100, Math.Max(value, 0));
        }
    }
}
