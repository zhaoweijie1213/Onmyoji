using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Main
{
    public static class JobTool
    {
        /// <summary>
        /// 获取游戏句柄
        /// </summary>
        /// <returns></returns>
        public static int GetFFoHandle()
        {
            Process[] processes = Process.GetProcessesByName("阴阳师-网易游戏");

            var p = processes.FirstOrDefault();

            if (p == null)
            {
                return 0;
            }
            else
            {
                return p.MainWindowHandle.ToInt32();
            }
        }
        /// <summary>
        /// 根据句柄获取游戏的位置
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="lpRect"></param>
        /// <returns></returns>
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }


        /// <summary>
        /// 根据句柄移动窗体
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="hWndInsertAfter"></param>
        /// <param name="x"></param>
        /// <param name="Y"></param>
        /// <param name="cx"></param>
        /// <param name="cy"></param>
        /// <param name="wFlags"></param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy, int wFlags);

    }
}
