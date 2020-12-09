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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Main.JobTool;

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
        MouseHookHelper.RECT winodwsSpace1 = new MouseHookHelper.RECT();
        MouseHookHelper.RECT winodwsSpace2 = new MouseHookHelper.RECT();
        MouseHookHelper.RECT winodwsSpace3 = new MouseHookHelper.RECT();
        bool mouseClick = false;
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

    
            CSharpAPIsDemo api = new CSharpAPIsDemo();
            //得到所有阴阳师的窗体
            var windowsList = api.GetAllDesktopWindows();
          
            MouseHookHelper.GetWindowRect(windowsList[0].hWnd, ref winodwsSpace1);
            MouseHookHelper.GetWindowRect(windowsList[1].hWnd, ref winodwsSpace2);
            MouseHookHelper.GetWindowRect(windowsList[2].hWnd, ref winodwsSpace3);
            //foreach (var item in windowsList)
            //{
            //    var s = 
            //}
            mouseClick = true;
            while (mouseClick)
            {
                Random rnd = new Random();
                if (mouseClick)
                {
                    //int firstX = rnd.Next(winodwsSpace1.Right - 20, winodwsSpace1.Right - 1);
                    int firstX = rnd.Next(1850, 1890);
                    //int firstY = rnd.Next(winodwsSpace1.Bottom + 1, winodwsSpace1.Bottom + 20);
                    int firstY = rnd.Next(913, 940);
                    //int SecondX = rnd.Next(winodwsSpace2.Left, winodwsSpace2.Right);
                    int SecondX = rnd.Next(1230, 1280);
                    //int SecondY = rnd.Next(winodwsSpace2.Top, winodwsSpace2.Bottom);
                    int SecondY = rnd.Next(160, 400);
                    //int ThirdX = rnd.Next(winodwsSpace3.Left, winodwsSpace3.Right);
                    int ThirdX = rnd.Next(420, 470);
                    //int ThirdY = rnd.Next(winodwsSpace3.Top, winodwsSpace3.Bottom);
                    int ThirdY = rnd.Next(160, 400);
                    //鼠标点击1
                    MouseHookHelper.LeftMouseClick(new MouseHookHelper.POINT()
                    {
                        //1356,220
                        X = firstX,
                        Y = firstY
                    });
                    Thread.Sleep(rnd.Next(500, 800));
                    //鼠标点击2
                    MouseHookHelper.LeftMouseClick(new MouseHookHelper.POINT()
                    {
                        //1356,220
                        X = SecondX,
                        Y = SecondY
                    });
                    Thread.Sleep(rnd.Next(1000, 1200));
                    MouseHookHelper.LeftMouseClick(new MouseHookHelper.POINT()
                    {
                        //1356,220
                        X = SecondX,
                        Y = SecondY
                    });
                    Thread.Sleep(rnd.Next(500, 800));
                    //鼠标点击3
                    MouseHookHelper.LeftMouseClick(new MouseHookHelper.POINT()
                    {
                        //1356,220
                        X = ThirdX,
                        Y = ThirdY
                    });
                    Thread.Sleep(rnd.Next(500, 800));
                    MouseHookHelper.LeftMouseClick(new MouseHookHelper.POINT()
                    {
                        //1356,220
                        X = ThirdX,
                        Y = ThirdY
                    });
                    Thread.Sleep(3000);
                }
            }
            //鼠标点击
            //MouseHookHelper.LeftMouseClick(new MouseHookHelper.POINT()
            //{
            //    //1356,220
            //    X = 1351,
            //    Y = 344
            //});
        }

        private void btnMouse_Click(object sender, EventArgs e)
        {
            Point screenPoint = Control.MousePosition;//鼠标相对于屏幕左上角的坐标

            Point formPoint = this.PointToClient(Control.MousePosition);//鼠标相对于窗体左上角的坐标
            //MessageBox.Show($"鼠标相对于屏幕左上角的坐标：{screenPoint.X},{screenPoint.Y}");
            //MessageBox.Show($"鼠标相对于窗体左上角的坐标：{formPoint.X},{formPoint.X}");
            txtWindowSpace.Text = $"{screenPoint.X},{screenPoint.Y}";
            txtFormSpace.Text = $"{formPoint.X},{formPoint.Y}";

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
                //全局钩子
                hHook = MouseHookHelper.SetWindowsHookEx((int)IdHookEnum.WH_MOUSE_LL, MyProcedure, Marshal.GetHINSTANCE(Assembly.GetExecutingAssembly().GetModules()[0]), 0);
                //IntPtr pInstance = Marshal.GetHINSTANCE(Assembly.GetExecutingAssembly().ManifestModule);
                //MouseHookHelper.SetWindowsHookEx((int)IdHookEnum.WH_MOUSE_LL, m_MouseHookProcedure, pInstance, 0);
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
            timerMouseEvent.Enabled = false;

        }

        private void stopClickBtn_Click(object sender, EventArgs e)
        {
            timerMouseEvent.Stop();
        }


        /// <summary>
        /// 获取窗口图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPictrue_Click(object sender, EventArgs e)
        {


            CSharpAPIsDemo api = new CSharpAPIsDemo();
            //得到所有阴阳师的窗体
            var windowsList = api.GetAllDesktopWindows();
            if (windowsList.Length==0)
            {
                MessageBox.Show("没有找到窗体");
                return;
            }
            foreach (var item in windowsList)
            {
                ////获取图片
                Image image = MouseHookHelper.Capture(item.hWnd);
                Bitmap bmp = new Bitmap(image);
                PicGetHelper.GetP(bmp);
            }
        }

        private void mainForm_KeyDown(object sender, KeyEventArgs e)
        {
            //  这里写具体实现
            if (e.KeyCode.Equals(Keys.F1))
            {
                MessageBox.Show("开始");
                startListen();
            }
            if (e.KeyCode.Equals(Keys.F4))
            {
                MessageBox.Show("结束");
            }
        }

        KeyEventHandler myKeyEventHandeler;
        KeyboardHook service = new KeyboardHook();
        /// <summary>
        /// 开始监听
        /// </summary>
        public void startListen()
        {
           
            var myKeyEventHandeler = new KeyEventHandler(mainForm_KeyDown);
            service.KeyDownEvent += myKeyEventHandeler;//钩住键按下
            service.Start();//安装键盘钩子
        }

        /// <summary>
        /// 结束监听
        /// </summary>
        public void stopListen()
        {
            if (myKeyEventHandeler != null)
            {
                service.KeyDownEvent -= myKeyEventHandeler;//取消按键事件
                myKeyEventHandeler = null;
                service.Stop();//关闭键盘钩子
            }
        }

        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
         
        }

        private void mainForm_SizeChanged(object sender, EventArgs e)
        {
            //窗体尺寸变体事件中，如何窗体是最小化状态就让窗体不显示在任务栏上 
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)//判断鼠标的按键
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
                this.Activate();
                this.ShowInTaskbar = true;
            }
        }
    }
}
