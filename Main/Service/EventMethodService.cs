using System;
using System.Collections.Generic;
using System.Text;
using static Main.MouseHookHelper;

namespace Main.Service
{
    /// <summary>
    /// 各种事件
    /// </summary>
    public class EventMethodService
    {
        public bool mouseClick { get; set; } = false;

        public const int spXmin = 0;
        public const int spXmax = 0;

        public const int spYmin = 0;
        public const int spYmax = 0;

        public List<RECT> GetRects()
        {
            CSharpAPIsDemo api = new CSharpAPIsDemo();
            List<RECT> rect = new List<RECT>();
            //得到所有窗体
            var windowsList = api.GetAllDesktopWindows();
            foreach (var item in windowsList)
            {
                //得到窗口的坐标
                RECT sp = new RECT();
                GetWindowRect(item.hWnd,  ref sp);
                rect.Add(sp);
            }
            return rect;
        }
        public void MouseClick(List<RECT> rect)
        {
            foreach (var item in rect)
            {

                int X = 0;
                int Y = 0;
                MouseHookHelper.LeftMouseClick(new MouseHookHelper.POINT()
                {
                    //1356,220
                    X = X,
                    Y = Y
                });
            }
        }
    }

}
