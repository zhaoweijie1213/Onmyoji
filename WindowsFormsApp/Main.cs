using OnmyojiJob.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class ToolsForm : Form
    {
        int hHook = 0;
        public ToolsForm()
        {
            InitializeComponent();
        }

        private void ToolsForm_Load(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //找到窗体
            IntPtr awin = MouseHookHelper.FindWindow("TXGuiFoundation", "Weight of the World (English Version) - MONACA (モナカ)   ");
            if (awin == IntPtr.Zero)
            {
                MessageBox.Show("没有找到窗体");
                return;
            }
            //设置为当前窗体
            MouseHookHelper.SetForegroundWindow(awin);
            MouseHookHelper.ShowWindow(awin, MouseHookHelper.SW_SHOWNOACTIVATE);//4、5
            LeftMouseClick(new MouseHookHelper.POINT()
            {
                X = 10,
                Y = 20
            });
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            if (hHook == 0)
            {
                var MyProcedure = new MouseHookHelper.HookProc(this.MouseHookProc);
                //这里挂节钩子
                hHook = MouseHookHelper.SetWindowsHookEx(hHook, MyProcedure, Marshal.GetHINSTANCE(Assembly.GetExecutingAssembly().GetModules()[0]), 0);
                if (hHook == 0)
                {
                    MessageBox.Show("请以管理员方式打开");
                    return;
                }
                button1.Text = "卸载钩子";
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
                button1.Text = "安装钩子";
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
                return MouseHookHelper.CallNextHookEx(hHook, nCode, wParam, lParam);
            }
        }
        private static void LeftMouseClick(MouseHookHelper.POINT pointInfo)
        {

            //先移动鼠标到指定位置
            MouseHookHelper.SetCursorPos(pointInfo.X, pointInfo.Y);

            //按下鼠标左键
            MouseHookHelper.mouse_event(MouseHookHelper.MOUSEEVENTF_LEFTDOWN,
                        pointInfo.X * 65536 / Screen.PrimaryScreen.Bounds.Width,
                        pointInfo.Y * 65536 / Screen.PrimaryScreen.Bounds.Height, 0, 0);

            //松开鼠标左键
            MouseHookHelper.mouse_event(MouseHookHelper.MOUSEEVENTF_LEFTUP,
                        pointInfo.X * 65536 / Screen.PrimaryScreen.Bounds.Width,
                        pointInfo.Y * 65536 / Screen.PrimaryScreen.Bounds.Height, 0, 0);

        }


    }
}
