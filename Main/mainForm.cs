using Main;
using Main.Enum;
using Main.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class mainForm : Form
    {
        //private static readonly int x = 1356;
        //private static readonly int y = 220;
        public mainForm()
        {
            InitializeComponent();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {

        }
        int hHook;
        /// <summary>
        /// 获取游戏句柄
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //IntPtr awin = MouseHookHelper.FindWindowEx(null,null,"Win32Window", "阴阳师-网易游戏");
            //IntPtr awin = MouseHookHelper.FindWindow("WeChatMainWndForPC", "微信");


            //if (awin == IntPtr.Zero)
            //{
            //    MessageBox.Show("没有找到窗体");
            //    return;
            //}
            ////获取窗体坐标信息
            //MouseHookHelper.RECT rect = new MouseHookHelper.RECT();
            //MouseHookHelper.GetWindowRect(awin, ref rect);
            //int width = rect.Right - rect.Left;             //窗口的宽度
            //int height = rect.Bottom - rect.Top;            //窗口的高度
            //int x = rect.Left;
            //int y = rect.Top;
            //var res = JobTool.GetFFoHandle();
            //SendKeys.Send("输入文本");//用于输入文字
            //SendKeys.SendWait("{ENTER}"); //用于输入按键命令

            //设置为当前窗体
            //MouseHookHelper.SetForegroundWindow(awin);
            //MouseHookHelper.ShowWindow(awin, MouseHookHelper.SW_SHOWNOACTIVATE);//4、5
            //设置鼠标位置
            //SetCursorPos(x,y);

            ////获取图片
            //Image image = MouseHookHelper.Capture(awin);
            //Bitmap bmp = new Bitmap(image);
            //PicGetHelper.GetP(bmp);
            CSharpAPIsDemo api = new CSharpAPIsDemo();
            //得到所有阴阳师的窗体
            var windowsList = api.GetAllDesktopWindows();
            foreach (var item in windowsList)
            {
                if (hHook == 0)
                {
                    var MyProcedure = new MouseHookHelper.HookProc(this.MouseHookProc);
                    var s = Marshal.GetHINSTANCE(Assembly.GetExecutingAssembly().GetModules()[0]);
                    var a = Process.GetCurrentProcess().Modules;

                    //这里挂节钩子
                   hHook = MouseHookHelper.SetWindowsHookEx((int)IdHookEnum.WH_MOUSE_LL, MyProcedure, item.hWnd, 0);
                    if (hHook == 0)
                    {
                        MessageBox.Show("请以管理员方式打开");
                        return;
                    }
                }
                else
                {
                    bool ret = MouseHookHelper.UnhookWindowsHookEx(hHook);
                    if (ret == false)
                    {
                        MessageBox.Show("请以管理员方式打开");
                        return;
                    }
                    hHook = 0;
                }
            }
            //鼠标点击
            MouseHookHelper.LeftMouseClick(new MouseHookHelper.POINT()
            {
                //1356,220
                X = 1351,
                Y = 344
            });
        }

        private void btnMouse_Click(object sender, EventArgs e)
        {
            Point screenPoint = Control.MousePosition;//鼠标相对于屏幕左上角的坐标

            Point formPoint = this.PointToClient(Control.MousePosition);//鼠标相对于窗体左上角的坐标
            //MessageBox.Show($"{screenPoint.X},{screenPoint.Y}");
            //MessageBox.Show($"{formPoint.X},{formPoint.X}");


        }


        //定义变量
        const int AnimationCount = 80;
        private Point endPosition;
        private int count;

        //结构体布局 本机位置
        [StructLayout(LayoutKind.Sequential)]
        struct NativeRECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

        [DllImport("user32.dll")]
        static extern bool GetWindowRect(HandleRef hwnd, out NativeRECT rect);
        //设置鼠标位置
        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int X, int Y);

        //设置鼠标按键和动作
        [DllImport("user32.dll")]
        static extern void mouse_event(MouseHookHelper.MouseEventFlag flags, int dx, int dy,
            uint data, UIntPtr extraInfo); //UIntPtr指针多句柄类型

        [DllImport("user32.dll")]
        static extern IntPtr FindWindow(string strClass, string strWindow);

        //该函数获取一个窗口句柄,该窗口雷鸣和窗口名与给定字符串匹配 hwnParent=Null从桌面窗口查找
        [DllImport("user32.dll")]
        static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter,
            string strClass, string strWindow);

        private void button1_Click(object sender, EventArgs e)
        {
            NativeRECT rect;
            //获取主窗体句柄
            IntPtr ptrTaskbar = MouseHookHelper.FindWindow("Win32Window", "阴阳师-网易游戏");
            //IntPtr ptrTaskbar = MouseHookHelper.FindWindow("WeChatMainWndForPC", "微信");
            if (ptrTaskbar == IntPtr.Zero)
            {
                MessageBox.Show("No windows found!");
                return;
            }
            //获取窗体大小
            GetWindowRect(new HandleRef(this, ptrTaskbar), out rect);
            endPosition.X = (rect.left + rect.right) / 2;
            endPosition.Y = (rect.top + rect.bottom) / 2;
            //判断点击按钮
            if (checkBox1.Checked)
            {
                //选择"查看鼠标运行的轨迹"
                this.count = AnimationCount;
                movementTimer.Start();
            }
            else
            {
                SetCursorPos(endPosition.X, endPosition.Y);
                mouse_event(MouseHookHelper.MouseEventFlag.LeftDown, 0, 0, 0, UIntPtr.Zero);
                mouse_event(MouseHookHelper.MouseEventFlag.LeftUp, 0, 0, 0, UIntPtr.Zero);
                txtMouse.Text = String.Format("{0},{1}", MousePosition.X, MousePosition.Y);
            }
        }

        private void movementTimer_Tick(object sender, EventArgs e)
        {
            int stepx = (endPosition.X - MousePosition.X) / count;
            int stepy = (endPosition.Y - MousePosition.Y) / count;
            count--;
            if (count == 0)
            {
                movementTimer.Stop();
                mouse_event(MouseHookHelper.MouseEventFlag.LeftDown, 0, 0, 0, UIntPtr.Zero);
                mouse_event(MouseHookHelper.MouseEventFlag.LeftUp, 0, 0, 0, UIntPtr.Zero);
            }
            txtMouse.Text = String.Format("{0},{1}", MousePosition.X, MousePosition.Y);
            mouse_event(MouseHookHelper.MouseEventFlag.Move, stepx, stepy, 0, UIntPtr.Zero);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (hHook == 0)
            {
                var MyProcedure = new MouseHookHelper.HookProc(this.MouseHookProc);
                //这里挂节钩子
                hHook = MouseHookHelper.SetWindowsHookEx((int)IdHookEnum.WH_MOUSE_LL, MyProcedure, Marshal.GetHINSTANCE(Assembly.GetExecutingAssembly().GetModules()[0]), 0);
                if (hHook == 0)
                {
                    MessageBox.Show("请以管理员方式打开");
                    return;
                }
                button2.Text = "卸载钩子";
            }
            else
            {
                bool ret = MouseHookHelper.UnhookWindowsHookEx(hHook);
                if (ret == false)
                {
                    MessageBox.Show("请以管理员方式打开");
                    return;
                }
                hHook = 0;
                button2.Text = "安装钩子";
            }
        }
        private int MouseHookProc(int nCode, IntPtr wParam, IntPtr lParam)
        {

            MouseHookHelper.MouseHookStruct MyMouseHookStruct = (MouseHookHelper.MouseHookStruct)Marshal.PtrToStructure(lParam, typeof(MouseHookHelper.MouseHookStruct));
            if (nCode < 0)
            {
                return MouseHookHelper.CallNextHookEx(hHook, nCode, wParam, lParam);
            }
            else
            {
                String strCaption = "x = " + MyMouseHookStruct.pt.X.ToString("d") + "  y = " + MyMouseHookStruct.pt.Y.ToString("d");
                this.Text = strCaption;
                txtMouse.Text = strCaption;
                return MouseHookHelper.CallNextHookEx(hHook, nCode, wParam, lParam);
            }
        }

        private void timerMouseEvent_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int firstX = rnd.Next(273,1000);
            int firstY = rnd.Next(140,483);
            int SecondX = rnd.Next(1150, 1850);
            int SecondY = rnd.Next(69, 470);

        }
    }
}
