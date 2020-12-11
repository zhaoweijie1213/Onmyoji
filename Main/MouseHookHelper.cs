﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main
{
    public class MouseHookHelper
    {

        #region 根据句柄寻找窗体并发送消息

        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        //参数1:指的是类名。参数2，指的是窗口的标题名。两者至少要知道1个
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern IntPtr FindWindowEx(IntPtr? parentHandle, IntPtr? childAfter, string lclassName, string windowTitle);



        [DllImport("user32.dll", EntryPoint = "SendMessage", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hwnd, uint wMsg, int wParam, string lParam);

        [DllImport("user32.dll", EntryPoint = "SendMessage", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hwnd, uint wMsg, int wParam, int lParam);

        #endregion

        #region 获取窗体位置
        /// <summary>
        /// 获取窗体位置信息
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="lpRect"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            /// <summary>
            /// x1
            /// </summary>
            public int Left;                             //最左坐标
            /// <summary>
            /// y1
            /// </summary>
            public int Top;                             //最上坐标
            /// <summary>
            /// x2
            /// </summary>
            public int Right;                           //最右坐标
            /// <summary>
            /// y2
            /// </summary>
            public int Bottom;                        //最下坐标
        }
        #endregion

        #region 设置窗体显示形式

        public enum nCmdShow : uint
        {
            SW_NONE,//初始值
            SW_FORCEMINIMIZE,//：在WindowNT5.0中最小化窗口，即使拥有窗口的线程被挂起也会最小化。在从其他线程最小化窗口时才使用这个参数。
            SW_MIOE,//：隐藏窗口并激活其他窗口。
            SW_MAXIMIZE,//：最大化指定的窗口。
            SW_MINIMIZE,//：最小化指定的窗口并且激活在Z序中的下一个顶层窗口。
            SW_RESTORE,//：激活并显示窗口。如果窗口最小化或最大化，则系统将窗口恢复到原来的尺寸和位置。在恢复最小化窗口时，应用程序应该指定这个标志。
            SW_SHOW,//：在窗口原来的位置以原来的尺寸激活和显示窗口。
            SW_SHOWDEFAULT,//：依据在STARTUPINFO结构中指定的SW_FLAG标志设定显示状态，STARTUPINFO 结构是由启动应用程序的程序传递给CreateProcess函数的。
            SW_SHOWMAXIMIZED,//：激活窗口并将其最大化。
            SW_SHOWMINIMIZED,//：激活窗口并将其最小化。
            SW_SHOWMINNOACTIVATE,//：窗口最小化，激活窗口仍然维持激活状态。
            SW_SHOWNA,//：以窗口原来的状态显示窗口。激活窗口仍然维持激活状态。
            SW_SHOWNOACTIVATE,//：以窗口最近一次的大小和状态显示窗口。激活窗口仍然维持激活状态。
            SW_SHOWNOMAL,//：激活并显示一个窗口。如果窗口被最小化或最大化，系统将其恢复到原来的尺寸和大小。应用程序在第一次显示窗口的时候应该指定此标志。
        }

        public const int SW_HIDE = 0;
        public const int SW_SHOWNORMAL = 1;
        public const int SW_SHOWMINIMIZED = 2;
        public const int SW_SHOWMAXIMIZED = 3;
        public const int SW_MAXIMIZE = 3;
        public const int SW_SHOWNOACTIVATE = 4;
        public const int SW_SHOW = 5;
        public const int SW_MINIMIZE = 6;
        public const int SW_SHOWMINNOACTIVE = 7;
        public const int SW_SHOWNA = 8;
        public const int SW_RESTORE = 9;

        [DllImport("User32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("User32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        #endregion

        #region 控制鼠标移动

        //移动鼠标 
        public const int MOUSEEVENTF_MOVE = 0x0001;
        //模拟鼠标左键按下 
        public const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        //模拟鼠标左键抬起 
        public const int MOUSEEVENTF_LEFTUP = 0x0004;
        //模拟鼠标右键按下 
        public const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
        //模拟鼠标右键抬起 
        public const int MOUSEEVENTF_RIGHTUP = 0x0010;
        //模拟鼠标中键按下 
        public const int MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        //模拟鼠标中键抬起 
        public const int MOUSEEVENTF_MIDDLEUP = 0x0040;
        //标示是否采用绝对坐标 
        public const int MOUSEEVENTF_ABSOLUTE = 0x8000;

        [Flags]
        public enum MouseEventFlag : uint
        {
            Move = 0x0001,
            LeftDown = 0x0002,
            LeftUp = 0x0004,
            RightDown = 0x0008,
            RightUp = 0x0010,
            MiddleDown = 0x0020,
            MiddleUp = 0x0040,
            XDown = 0x0080,
            XUp = 0x0100,
            Wheel = 0x0800,
            VirtualDesk = 0x4000,
            Absolute = 0x8000
        }

        //[DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        /// <summary>
        /// 鼠标移动到指定位置
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool SetCursorPos(int X, int Y);
        /// <summary>
        /// 鼠标事件
        /// </summary>
        /// <param name="dwFlags"></param>
        /// <param name="dx"></param>
        /// <param name="dy"></param>
        /// <param name="cButtons"></param>
        /// <param name="dwExtraInfo"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern int mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        #endregion

        #region 获取坐标钩子

        [StructLayout(LayoutKind.Sequential)]
        public class POINT
        {
            public int X;
            public int Y;
        }

        [StructLayout(LayoutKind.Sequential)]
        public class MouseHookStruct
        {
            public POINT pt;
            public int hwnd;
            public int wHitTestCode;
            public int dwExtraInfo;
        }

        public delegate int HookProc(int nCode, IntPtr wParam, IntPtr lParam);

        //安装钩子
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="idHook"></param>
        ///// <param name="lpfn"></param>
        ///// <param name="pInstance"></param>
        ///// <param name="threadId"></param>
        ///// <returns></returns>
        //[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall)]
        //public static extern IntPtr SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr pInstance, int threadId);
        //卸载钩子
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern bool UnhookWindowsHookEx(int idHook);
        //调用下一个钩子
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int CallNextHookEx(int idHook, int nCode, IntPtr wParam, IntPtr lParam);

        #endregion

        public static void LeftMouseClick(MouseHookHelper.POINT pointInfo)
        {

            //先移动鼠标到指定位置
            SetCursorPos(pointInfo.X, pointInfo.Y);

            //按下鼠标左键
            mouse_event(MouseHookHelper.MOUSEEVENTF_LEFTDOWN,
                        pointInfo.X * 65536 / Screen.PrimaryScreen.Bounds.Width,
                        pointInfo.Y * 65536 / Screen.PrimaryScreen.Bounds.Height, 0, 0);
            //随机间隔时间,防止规律按下
            Random random = new Random();
            Thread.Sleep(random.Next(200,500));


            //松开鼠标左键
            mouse_event(MouseHookHelper.MOUSEEVENTF_LEFTUP,
                        pointInfo.X * 65536 / Screen.PrimaryScreen.Bounds.Width,
                        pointInfo.Y * 65536 / Screen.PrimaryScreen.Bounds.Height, 0, 0);

        }

        [DllImport("user32.dll")]
        internal extern static IntPtr GetDesktopWindow();

        [DllImport("user32.dll")]
        internal extern static IntPtr GetDC(IntPtr windowHandle);

        [DllImport("gdi32.dll")]
        internal extern static IntPtr GetCurrentObject(IntPtr hdc, ushort objectType);

        [DllImport("user32.dll")]
        internal extern static void ReleaseDC(IntPtr hdc);
        public static Image Capture(IntPtr desktopWindow)
        {
            //IntPtr desktopWindow = GetDesktopWindow();

            IntPtr desktopDC = GetDC(desktopWindow);
            IntPtr desktopBitmap = GetCurrentObject(desktopDC, 7);

            Image desktopImage = Image.FromHbitmap(desktopBitmap);

            ReleaseDC(desktopDC);

            return desktopImage;
        }

        //[DllImport("user32.dll")]
        //[return: MarshalAs(UnmanagedType.Bool)]
        //static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);

        //[StructLayout(LayoutKind.Sequential)]
        //public struct RECT
        //{
        //    public int Left; //最左坐标
        //    public int Top; //最上坐标
        //    public int Right; //最右坐标
        //    public int Bottom; //最下坐标
        //}

    }
}
