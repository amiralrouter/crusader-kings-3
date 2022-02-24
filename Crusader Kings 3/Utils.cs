using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Crusader_Kings_3 {
    static class Utils {

        [DllImport("gdi32.dll", EntryPoint = "DeleteObject")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeleteObject([In] IntPtr hObject);

        // return string in bytes until null byte
        public static string GetString(byte[] buffer) {
            int stringLength = buffer.TakeWhile(b => b != 0).Count();
            return Encoding.UTF8.GetString(buffer, 0, stringLength);
        }


        // return value min 0 max 100
        public static int HundredLimit(int value) {
            return Math.Min(100, Math.Max(value, 0));
        }


        public static List<Timer> Timers = new List<Timer>();
        public static void CreateTimer(int interval, Action action) {
            Timer timer = new Timer(o => Application.Current.Dispatcher.Invoke(action), null, interval, interval);
            Timers.Add(timer);
        }
        // stop and clear all timers
        public static void ClearTimers() { 
            foreach (Timer timer in Timers) {
                timer.Dispose();
            }
            Timers.Clear();
        }



        public static List<Trait> Traits = new List<Trait>();

        public static BitmapSource BitmapToImageSource(Bitmap bmp){
            var handle = bmp.GetHbitmap();
            try {
                ImageSource newSource = Imaging.CreateBitmapSourceFromHBitmap(handle, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());

                DeleteObject(handle);
                return (BitmapSource)newSource;
            }
            catch (Exception ex) {
                DeleteObject(handle);
                return null;
            }
        }
    }
}
