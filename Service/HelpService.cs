using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Collections.Generic;

public class CSharpAPIsDemo
{
    private delegate bool WNDENUMPROC(IntPtr hWnd, int lParam);
    [DllImport("user32.dll")]
    private static extern bool EnumWindows(WNDENUMPROC lpEnumFunc, int lParam);
    //[DllImport("user32.dll")]    
    //private static extern IntPtr FindWindowW(string lpClassName, string lpWindowName);    
    [DllImport("user32.dll")]
    private static extern int GetWindowTextW(IntPtr hWnd, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder lpString, int nMaxCount);
    [DllImport("user32.dll")]
    private static extern int GetClassNameW(IntPtr hWnd, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder lpString, int nMaxCount);

    public struct WindowInfo
    {
        public IntPtr hWnd;
        public string szWindowName;
        public string szClassName;
    }

    /// <summary>
    /// 获取所有的窗口
    /// </summary>
    /// <returns></returns>
    public WindowInfo[] GetAllDesktopWindows()
    {
        List<WindowInfo> wndList = new List<WindowInfo>();

        //enum all desktop windows    
        EnumWindows(delegate (IntPtr hWnd, int lParam)
        {
            WindowInfo wnd = new WindowInfo();
            StringBuilder sb = new StringBuilder(256);
            //get hwnd    
            wnd.hWnd = hWnd;
            //get window name    
            GetWindowTextW(hWnd, sb, sb.Capacity);
            wnd.szWindowName = sb.ToString();
            //get window class    
            GetClassNameW(hWnd, sb, sb.Capacity);
            wnd.szClassName = sb.ToString();
            //add it into list    
            if (wnd.szClassName== "Win32Window"&&wnd.szWindowName== "阴阳师-网易游戏")
            {
                wndList.Add(wnd);
            }
            return true;
        }, 0);

        return wndList.ToArray();
    }
}
