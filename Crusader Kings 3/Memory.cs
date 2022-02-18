﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;

namespace Crusader_Kings_3 {
    static class Memory {

        [StructLayout(LayoutKind.Sequential)]
        protected struct MEMORY_BASIC_INFORMATION {
            public IntPtr BaseAddress;
            public IntPtr AllocationBase;
            public uint AllocationProtect;
            public UIntPtr RegionSize;
            public uint State;
            public uint Protect;
            public uint Type;
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern int VirtualQueryEx(IntPtr hProcess, IntPtr lpAddress, out MEMORY_BASIC_INFORMATION lpBuffer, uint dwLength);
 
 
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);


        // import dll for read memory for 64 bit process and 8 byte pointer
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool ReadProcessMemory(IntPtr hProcess, Int64 lpBaseAddress, [Out] byte[] lpBuffer, uint dwSize, out int lpNumberOfBytesRead);

        // import dll for write memory for 64 bit process and 8 byte pointer
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteProcessMemory(IntPtr hProcess, Int64 lpBaseAddress, [Out] byte[] lpBuffer, uint dwSize, out int lpNumberOfBytesWritten);

        // import dll for create virtual alloc for 64 bit process and 8 byte pointer
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);




        public static Process process;
        public static IntPtr handle;

        public static IntPtr baseAddress{
            get {
                return process.MainModule.BaseAddress;
            }
        }

        public static void Connect() {
            Process[] processes = Process.GetProcessesByName("ck3");
            if (processes.Length == 0) {
                MessageBox.Show("Could not find Crusader Kings 3 process ck3.exe");
                return;
            }

            process = processes[0];
            handle = OpenProcess(0x1F0FFF, false, process.Id); 
        }


        // create virtual alloc for process memory
        public static Int64 VirtualAlloc(int size) {
            return (Int64)VirtualAllocEx(handle, IntPtr.Zero, (uint)size, 0x1000, 0x40); 
        }


        // read bytes from process memory
        public static byte[] getBytes(Int64 address, int size) {
            byte[] buffer = new byte[size];
            int bytesRead = 0;
            ReadProcessMemory(handle, address, buffer, (uint)size, out bytesRead);
            return buffer;
        }

        // write bytes to process memory
        public static void setBytes(Int64 address, byte[] bytes) {
            int bytesWritten = 0;
            WriteProcessMemory(handle, address, bytes, (uint)bytes.Length, out bytesWritten);
        }

        // read single byte from process memory
        public static byte getByte(Int64 address) { 
            return getBytes(address, 1)[0];
        } 

        // write single byte to process memory
        public static void setByte(Int64 address, byte value) {
            setBytes(address, new byte[] { value });
        }

        // read Int64 from process memory
        public static Int64 getInt64(Int64 address) {   
            return BitConverter.ToInt64(getBytes(address, 8), 0);
        }  

        // write Int64 to process memory
        public static void setInt64(Int64 address, Int64 value) {
            setBytes(address, BitConverter.GetBytes(value));
        }

        // read Int32 from process memory
        public static int getInt(Int64 address) {   
            return BitConverter.ToInt32(getBytes(address, 4), 0);
        }

        // write Int32 to process memory
        public static void setInt(Int64 address, int value) { 
            setBytes(address, BitConverter.GetBytes(value));
        }

        // read Int16 from process memory
        public static short getInt16(Int64 address) {   
            return BitConverter.ToInt16(getBytes(address, 2), 0);
        }

        // write Int16 to process memory
        public static void setInt16(Int64 address, short value) {
            setBytes(address, BitConverter.GetBytes(value));
        }

        // read Integer8 from process memory
        public static int getInteger8(Int64 address) { 
            // read 8 byte as unsigned int64 and scale it 100000x to integer 
            byte[] bytes = getBytes(address, 8);
            Int64 value = BitConverter.ToInt64(bytes, 0);
            return (int)(value / 100000);
        }

        // write Integer8 to process memory
        public static void setInteger8(Int64 address, int value) {
            Int64 scaledValue = value * 100000;
            Int64 orginalValue = getInt64(address);
            Int64 different = scaledValue - orginalValue; 
            setInt64(address, orginalValue + different);
        }

        // read string from process memory
        public static string getString(Int64 address, int size = 256, bool clean = false) {
            byte[] buffer = getBytes(address, size); 
            int stringLength = buffer.TakeWhile(b => b != 0).Count();
            return Encoding.UTF8.GetString(buffer, 0, stringLength); 
        }

        // write string to process memory
        public static void setString(Int64 address, string value) {
            byte[] buffer = Encoding.ASCII.GetBytes(value);
            setBytes(address, buffer);
        }
    }
}