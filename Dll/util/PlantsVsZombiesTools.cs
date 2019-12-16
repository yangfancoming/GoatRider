using System;
using System.Runtime.InteropServices;
using Dll.log4c;

namespace GoatTools
{
    public static class PlantsVsZombiesTools
    {


        [DllImport("kernel32.dll")]
        private static extern void CloseHandle(IntPtr hObject);

        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowThreadProcessId(IntPtr hwnd, out int ID);
        [DllImport("kernel32.dll")]
        public static extern int OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);


        //①要读取的进程句柄②读取的基址③读取出来之后保存的缓冲区④要读取的字节数⑤实际读取的字节数
        [DllImportAttribute("kernel32.dll", EntryPoint = "ReadProcessMemory")]
        public static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, IntPtr lpBuffer, int nSize, IntPtr lpNumberOfBytesRead);


        //①OpenProcess返回的进程句柄  ②要写的内存首地址 ③指向要写的数据的指针 ④要写入的字节数  ⑤返回值 非零值代表成功
        [DllImportAttribute("kernel32.dll", EntryPoint = "WriteProcessMemory")]
        public static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, int[] lpBuffer, int nSize, IntPtr lpNumberOfBytesWritten);

        
        public static int ReadMemory(String titleName, int startAddr, int readSize)
        {
            IntPtr maindHwnd = FindWindow(null, titleName); //获取游戏的窗口句柄
            if (maindHwnd == IntPtr.Zero) { Log4C.log.Debug("未找到游戏！"); return 0; }
            int PID;
            GetWindowThreadProcessId(maindHwnd, out PID); //利用上步获取的窗口句柄 获取窗口的进程ID,保存在param2中
            IntPtr hProcess = (IntPtr)OpenProcess(0x1F0FFF, true, PID);//如果打开进程成功的话  返回值为非零！
            IntPtr byteAddress = Marshal.UnsafeAddrOfPinnedArrayElement(new byte[readSize], 0); //获取缓冲区地址
            ReadProcessMemory(hProcess, (IntPtr)startAddr, byteAddress, readSize, IntPtr.Zero); //将制定内存中的值读入缓冲区
            int fuck = Marshal.ReadInt32(byteAddress);
            CloseHandle(hProcess);//OpenProcess之后  读完数据之后 要记得关闭该句柄！
            return fuck;
        }

        public static void WriteMemory(String titleName, int startAddr, int[] content, int writeSize)
        {
            IntPtr maindHwnd = FindWindow(null, titleName); //获取游戏的窗口句柄
            if (maindHwnd == IntPtr.Zero) { Log4C.log.Debug("未找到游戏！"); return; }
            int PID;
            GetWindowThreadProcessId(maindHwnd, out PID); //利用上步获取的窗口句柄 获取窗口的进程ID,保存在param2中
            IntPtr hProcess = (IntPtr)OpenProcess(0x1F0FFF, true, PID);//如果打开进程成功的话  返回值为非零！
            WriteProcessMemory(hProcess, (IntPtr)startAddr, content, writeSize, IntPtr.Zero);
            CloseHandle(hProcess);//OpenProcess之后  读完数据之后 要记得关闭该句柄！
        }

        public static void WriteMemory(String titleName, int startAddr,int content, int writeSize)
        {
            IntPtr maindHwnd = FindWindow(null, titleName); //获取游戏的窗口句柄
            if (maindHwnd == IntPtr.Zero) {  Log4C.log.Debug("未找到游戏！"); return; }
            int PID;
            GetWindowThreadProcessId(maindHwnd, out PID); //利用上步获取的窗口句柄 获取窗口的进程ID,保存在param2中
            IntPtr hProcess = (IntPtr)OpenProcess(0x1F0FFF, true, PID);//如果打开进程成功的话  返回值为非零！
            WriteProcessMemory(hProcess, (IntPtr)startAddr, new int[] { content }, writeSize, IntPtr.Zero);
            CloseHandle(hProcess);//OpenProcess之后  读完数据之后 要记得关闭该句柄！
        }
    }
}
