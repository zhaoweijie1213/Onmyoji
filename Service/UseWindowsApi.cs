using System;
using System.Runtime.InteropServices;

namespace Service
{
    
    public class UseWindowsApi
    {
        /// <summary>
        /// 设置鼠标的位置
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int X, int Y);
        [DllImport("user32.dll")]
        static extern void mouse_event(MouseEventFlag flags, int dx, int dy, uint data, UIntPtr extraInfo);
        [DllImport("user32.dll")]
        static extern IntPtr FindWindow(string strClass, string strWindow);

    }
}
