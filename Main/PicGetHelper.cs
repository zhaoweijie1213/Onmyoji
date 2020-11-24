using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main
{
    /// <summary>
    /// 图片
    /// </summary>
    public class PicGetHelper
    {

    }
    /// <summary>
    /// clsCaptureDesktop 的摘要说明。
    /// </summary>
    public class clsCaptureDesktop
    {

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern bool BitBlt(
        IntPtr hdcDest, //目标设备的句柄
                    int nXDest, //目标对像的左上角的X坐标
                    int nYDest, //目标对象的左上角的Y坐标
                    int nWidth, //目标对象的矩形的宽度
                    int nHeight, //目标对象的矩形的长度
                    IntPtr hdcSrc, //源设备的句柄
                    int nXSrc, //源对像的左上角的X坐标
                    int nYSrc, //源对象的左上角的Yw坐标
                    System.Int32 dwRop //光栅的操作值
                    );
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr CreateDC(
        string lpszDriver, // 驱动名称
                    string lpszDevice, // 设备名称
                    string lpszOutput, // 无用，可以设定位"NULL"
                    IntPtr lpInitData // 任意的打印机数据
                    );

        public Bitmap Capture(Size size)
        {
            Bitmap bmpDeskTop = null;

            ArrayList arryHideWidow = new ArrayList();         //记录隐藏的窗体，以便恢复过来
            foreach (Window w in new Windows())  //枚举所有窗体
            {
                arryHideWidow.Add(w);
                w.Visible = false;  //隐藏所有窗口(包括活动的和非活动的)
            }

            try
            {
                IntPtr dc1 = CreateDC("DISPLAY", null, null, (IntPtr)null);
                //创建显示器的DC
                Graphics g1 = Graphics.FromHdc(dc1);
                //由一个指定的设备的句柄创建一个新的Graphics对象
                bmpDeskTop = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, g1);
                //根据屏幕大小创建一个与之相同大小的Bitmap对象
                Graphics g2 = Graphics.FromImage(bmpDeskTop);
                //获得屏幕的句柄
                IntPtr dc3 = g1.GetHdc();
                //获得位图的句柄
                IntPtr dc2 = g2.GetHdc();
                //把当前屏幕捕获到位图对象中
                BitBlt(dc2, 0, 0, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, dc3, 0, 0, 13369376);
                //把当前屏幕拷贝到位图中
                g1.ReleaseHdc(dc3);
                //释放屏幕句柄
                g2.ReleaseHdc(dc2);

                g1.Dispose();
                g2.Dispose();
            }
            catch
            {
            }
            //释放位图句柄
            foreach (Window w in arryHideWidow)
            {
                w.Visible = true; //恢复隐藏的窗口
            }

            Bitmap bmpRet = new Bitmap(bmpDeskTop, size);
            bmpDeskTop.Dispose();
            bmpDeskTop = null;

            return bmpRet;
        }

        public clsCaptureDesktop()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }



    }


    public class Window
    {
        /// 

        /// Win32 API Imports

        /// 

        [DllImport("user32.dll")]
        private static extern
        bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll")]
        private static extern
        bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        private static extern
        bool IsIconic(IntPtr hWnd);
        [DllImport("user32.dll")]
        private static extern
        bool IsZoomed(IntPtr hWnd);
        [DllImport("user32.dll")]
        private static extern
        IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        private static extern
        IntPtr GetWindowThreadProcessId(IntPtr hWnd, IntPtr ProcessId);
        [DllImport("user32.dll")]
        private static extern
        IntPtr AttachThreadInput(IntPtr idAttach, IntPtr idAttachTo, int fAttach);

        /// 

        /// Win32 API Constants for ShowWindowAsync()

        /// 

        private const int SW_HIDE = 0;
        private const int SW_SHOWNORMAL = 1;
        private const int SW_SHOWMINIMIZED = 2;
        private const int SW_SHOWMAXIMIZED = 3;
        private const int SW_SHOWNOACTIVATE = 4;
        private const int SW_RESTORE = 9;
        private const int SW_SHOWDEFAULT = 10;

        /// 

        /// Private Fields

        /// 

        private IntPtr m_hWnd;
        private string m_Title;
        private bool m_Visible = true;
        private string m_Process;
        private bool m_WasMax = false;

        /// 

        /// Window Object's Public Properties

        /// 

        public IntPtr hWnd
        {
            get { return m_hWnd; }
        }
        public string Title
        {
            get { return m_Title; }
        }
        public string Process
        {
            get { return m_Process; }
        }

        /// 

        /// Sets this Window Object's visibility

        /// 

        public bool Visible
        {
            get { return m_Visible; }
            set
            {
                //show the window

                if (value == true)
                {
                    if (m_WasMax)
                    {
                        if (ShowWindowAsync(m_hWnd, SW_SHOWMAXIMIZED))
                            m_Visible = true;
                    }
                    else
                    {
                        if (ShowWindowAsync(m_hWnd, SW_SHOWNORMAL))
                            m_Visible = true;
                    }
                }
                //hide the window

                if (value == false)
                {
                    m_WasMax = IsZoomed(m_hWnd);
                    if (ShowWindowAsync(m_hWnd, SW_HIDE))
                        m_Visible = false;
                }
            }
        }

        /// 

        /// Constructs a Window Object

        /// 

        /// Title Caption

        /// Handle

        /// Owning Process

        public Window(string Title, IntPtr hWnd, string Process)
        {
            m_Title = Title;
            m_hWnd = hWnd;
            m_Process = Process;
        }

        //Override ToString() 

        public override string ToString()
        {
            //return the title if it has one, if not return the process name

            if (m_Title.Length > 0)
            {
                return m_Title;
            }
            else
            {
                return m_Process;
            }
        }

        /// 

        /// Sets focus to this Window Object

        /// 

        public void Activate()
        {
            if (m_hWnd == GetForegroundWindow())
                return;

            IntPtr ThreadID1 = GetWindowThreadProcessId(GetForegroundWindow(),
            IntPtr.Zero);
            IntPtr ThreadID2 = GetWindowThreadProcessId(m_hWnd, IntPtr.Zero);

            if (ThreadID1 != ThreadID2)
            {
                AttachThreadInput(ThreadID1, ThreadID2, 1);
                SetForegroundWindow(m_hWnd);
                AttachThreadInput(ThreadID1, ThreadID2, 0);
            }
            else
            {
                SetForegroundWindow(m_hWnd);
            }

            if (IsIconic(m_hWnd))
            {
                ShowWindowAsync(m_hWnd, SW_RESTORE);
            }
            else
            {
                ShowWindowAsync(m_hWnd, SW_SHOWNORMAL);
            }
        }
    }

    /// 

    /// Collection used to enumerate Window Objects

    /// 

    public class Windows : IEnumerable, IEnumerator
    {
        /// 

        /// Win32 API Imports

        /// 

        [DllImport("user32.dll")]
        private static extern
        int GetWindowText(int hWnd, StringBuilder title, int size);
        [DllImport("user32.dll")]
        private static extern
        int GetWindowModuleFileName(int hWnd, StringBuilder title, int size);
        [DllImport("user32.dll")]
        private static extern
        int EnumWindows(EnumWindowsProc ewp, int lParam);
        [DllImport("user32.dll")]
        private static extern
        bool IsWindowVisible(int hWnd);

        //delegate used for EnumWindows() callback function

        public delegate bool EnumWindowsProc(int hWnd, int lParam);

        private int m_Position = -1; // holds current index of wndArray, 

        // necessary for IEnumerable


        ArrayList wndArray = new ArrayList(); //array of windows


        //Object's private fields

        private bool m_invisible = false;
        private bool m_notitle = false;

        /// 

        /// Collection Constructor with additional options

        /// 

        /// Include invisible Windows

        /// Include untitled Windows

        public Windows(bool Invisible, bool Untitled)
        {
            m_invisible = Invisible;
            m_notitle = Untitled;

            //Declare a callback delegate for EnumWindows() API call

            EnumWindowsProc ewp = new EnumWindowsProc(EvalWindow);
            //Enumerate all Windows

            EnumWindows(ewp, 0);
        }
        /// 

        /// Collection Constructor

        /// 

        public Windows()
        {
            //Declare a callback delegate for EnumWindows() API call

            EnumWindowsProc ewp = new EnumWindowsProc(EvalWindow);
            //Enumerate all Windows

            EnumWindows(ewp, 0);
        }
        //EnumWindows CALLBACK function

        private bool EvalWindow(int hWnd, int lParam)
        {
            if (m_invisible == false && !IsWindowVisible(hWnd))
                return (true);

            StringBuilder title = new StringBuilder(256);
            StringBuilder module = new StringBuilder(256);

            GetWindowModuleFileName(hWnd, module, 256);
            GetWindowText(hWnd, title, 256);

            if (m_notitle == false && title.Length == 0)
                return (true);

            wndArray.Add(new Window(title.ToString(), (IntPtr)hWnd,
            module.ToString()));

            return (true);
        }

        //implement IEnumerable

        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }
        //implement IEnumerator

        public bool MoveNext()
        {
            m_Position++;
            if (m_Position < wndArray.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Reset()
        {
            m_Position = -1;
        }
        public object Current
        {
            get
            {
                return wndArray[m_Position];
            }
        }
    }
}
