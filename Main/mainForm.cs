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
using static CSharpAPIsDemo;
using static Main.JobTool;

namespace WindowsFormsApp
{
    public partial class mainForm : Form
    {
        //private static readonly int x = 1356;
        //private static readonly int y = 220;

        ///// <summary>
        ///// 监听
        ///// </summary>
        //Task listenKey;

        ///// <summary>
        ///// 正在运行
        ///// </summary>
        //bool isRunning = false;
        KeyEventHandler myKeyEventHandeler;
        readonly KeyboardHook service = new KeyboardHook();
        bool task = false;
        int min = 0;
        public mainForm()
        {
            InitializeComponent();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // 用双缓冲绘制窗口的所有子控件
                return cp;
            }
        }


        private void mainForm_Load(object sender, EventArgs e)
        {
            startListen();
            //listenKey = Task.Run(() =>
            //{
            //    startListen();
            //});
            //_ = listenKey;
        }
        int hHook;
        List<MouseHookHelper.RECT> rects;
        WindowInfo[] windowInfos;
        /// <summary>
        /// 获取游戏句柄
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //EventMethodService eventMethod = new EventMethodService
            //{
            //    mouseClick = true
            //};
            //得到所有阴阳师的窗体
            EventMethodService eventMethod = new EventMethodService();
            rects = eventMethod.GetRects(ref windowInfos);
            if (rects.Count()>0)
            {
                MessageBox.Show("查找窗体成功!");
                //timerMouseEvent.Enabled = true;
                min = txtMin.Text == null ? 22 : Convert.ToInt32(txtMin.Text);
            }
            else
            {
                MessageBox.Show("查找窗体失败!请确认开启了游戏!");
            }

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

        int count = 1;
        double totalSecond = 0;
        private void timerMouseEvent_Tick(object sender, EventArgs e)
        {
            if (task)
            {
                timerMouseEvent.Stop();
                //eventMethod.mouseClick = true;
                if (rects.Count() == 0)
                {
                    task = false;
                    MessageBox.Show("没有找到窗体!");
                }
                else
                {
                    _ = MouseClickMethod(DateTime.Now.Second);
                }
                //timerMouseEvent.Start();
            }
        }
        /// <summary>
        /// 异步方法
        /// </summary>
        Task quanTask;
        bool contrastPic = false;
        /// <summary>
        /// 鼠标点击方法
        /// </summary>
        /// <param name="flag"></param>
        /// <returns></returns>
        public async Task MouseClickMethod(int flag)
        {
            if (quanTask != null && !quanTask.IsCompleted)
            {
                //Console.WriteLine("-------上一次还未完成--------");
                return;
            }

            quanTask = Task.Run(() =>
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                //耗时程序
                EventMethodService eventMethod = new EventMethodService();
                //txtMouse.Text = "开始";
                //开始
                eventMethod.MouseClick(rects);

                this.Activate();
                //timerMouseEvent.Stop();
                Thread.Sleep((min + 4) * 1000);
                //timerMouseEvent.Start();
                TaskExcuteService taskExcuteService = new TaskExcuteService();
               
                while (!contrastPic)
                {
                    contrastPic = taskExcuteService.StartTask(windowInfos);
                    //2 结算 step1
                    eventMethod.SecondMouseClick(rects);
                    ////3 结算 step2
                    //eventMethod.SecondMouseClick(rects);
                    //Thread.Sleep(1000);
                }

                sw.Stop();
                TimeSpan ts = sw.Elapsed;
                txtMouse.Text = ts.TotalSeconds.ToString();
                txtWindowSpace.Text = $"共{count++}次";
                totalSecond += ts.TotalSeconds;
                txtFormSpace.Text = $"共{totalSecond / 60}分钟";

            });//委托方法
            await quanTask;


            //判断是否已完成
            if (quanTask.IsCompleted)
            {

                timerMouseEvent.Start();
                //Console.WriteLine(flag + "==============完成===========");
            }
            else
            {
                timerMouseEvent.Stop();
            }
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


        /// <summary>
        /// 键盘监听
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainForm_KeyDown(object sender, KeyEventArgs e)
        {
            //EventMethodService eventMethod = new EventMethodService();
            //  这里写具体实现
            if (e.KeyCode.Equals(Keys.F1) && task == false)
            {
                //MessageBox.Show("Task Start!");
                task = true;
                timerMouseEvent.Start();
            }
            if (e.KeyCode.Equals(Keys.F4) && task == true)
            {
                task = false;
                timerMouseEvent.Stop();
                MessageBox.Show("Task end!");
            }
        }

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

        private void mainForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar.Equals(Keys.F1))
            //{
            //    task = true;
            //}
            //if (e.KeyChar.Equals(Keys.F4))
            //{
            //    //timerMouseEvent.Stop();
            //    //eventMethod.mouseClick = false;
            //    task = false;
            //    MessageBox.Show("任务结束");
            //}
        }

        private void txtMouse_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMin_TextChanged(object sender, EventArgs e)
        {
            min = Convert.ToInt32(txtMin.Text);
        }
    }
}
