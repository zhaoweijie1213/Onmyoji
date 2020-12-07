
//using System.Drawing;
//using System.Text;
//using System.Windows.Forms;
//using System.Runtime.InteropServices;
//using System;

//namespace SimulateMouse
//{



//    public partial class DemoForm : Form
//    {
//        [StructLayout(LayoutKind.Sequential)] struct NativeRECT { public int left; public int top; public int right; public int bottom; }
//        [Flags]
//        enum MouseEventFlag : uint// 设置 鼠标 动作 的 键值 { Move = 0x0001, LeftDown = 0x0002, LeftUp = 0x0004, RightDown = 0x0008,
//        { 
//                RightUp = 0x0010,
//            MiddleDown = 0x0020,
//            MiddleUp = 0x0040,
//            XDown = 0x0080, XUp =
//              0x0100, Wheel = 0x0800,
//            VirtualDesk = 0x4000,
//            Absolute = 0x8000
//        }
//    [DllImport(" user32. dll")] static extern bool SetCursorPos(int X, int Y);[DllImport(" user32. dll")] static extern void mouse_ event (MouseEventFlag flags, int dx, int dy, uint data, UIntPtr extraInfo); [DllImport(" user32. dll")]
//    static extern IntPtr FindWindow(string strClass, string strWindow); [DllImport(" user32. dll")]
//    static extern IntPtr FindWindowEx(HandleRef

//    HandleRef hwndParent, HandleRef hwndChildAfter, string strClass, string strWindow); [DllImport(" user32. dll")]
//    static extern bool GetWindowRect(HandleRef hwnd, out NativeRECT rect); const int AnimationCount = 80; private Point endPosition; private int count; public DemoForm() { InitializeComponent(); }
//    private void btnStart_ Click(object sender, EventArgs e)
//    {
//        NativeRECT rect; IntPtr ptrTaskbar = FindWindow(" Shell_ TrayWnd", null); if (ptrTaskbar == IntPtr.Zero)
//        {

//            MessageBox.Show(" No taskbar found."); return;
//        }
//        IntPtr ptrStartBtn = FindWindowEx(new HandleRef(this, ptrTaskbar), new HandleRef(this, IntPtr.Zero), "Button", null); if (ptrStartBtn == IntPtr.Zero) { MessageBox.Show(" No start button found."); return; }
//        GetWindowRect(new HandleRef(this, ptrStartBtn), out rect); endPosition.X = (rect.left + rect.right) / 2; endPosition.Y = (rect.top + rect.bottom) / 2; if (chkAnimation.Checked)
//        {
//            this.count = AnimationCount;

//            movementTimer.Start();
//        }
//        else { SetCursorPos(endPosition.X, endPosition.Y); mouse_ event(MouseEventFlag.LeftDown, 0, 0, 0, UIntPtr.Zero); mouse_ event(MouseEventFlag.LeftUp, 0, 0, 0, UIntPtr.Zero); }
//    }
//    private void movementTimer_ Tick(object sender, EventArgs e)
//    {
//        int stepx = (endPosition.X - MousePosition.X) / count; int stepy = (endPosition.Y - MousePosition.Y) / count; count--; if (count == 0)
//        {

//            movementTimer.Stop(); mouse_ event(MouseEventFlag.LeftDown, 0, 0, 0, UIntPtr.Zero); mouse_ event(MouseEventFlag.LeftUp, 0, 0, 0, UIntPtr.Zero);
//        }
//        tbCursor.Text = String.Format("({ 0}, {1})", MousePosition.X, MousePosition.Y); mouse_ event(MouseEventFlag.Move, stepx, stepy, 0, UIntPtr.Zero);
//    }
//} }
 
