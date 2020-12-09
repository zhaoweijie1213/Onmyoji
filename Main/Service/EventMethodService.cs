using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using static Main.MouseHookHelper;

namespace Main.Service
{
    /// <summary>
    /// 各种事件
    /// </summary>
    public class EventMethodService
    {
        public List<RECT> GetRect()
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
        /// <summary>
        /// 鼠标点击
        /// </summary>
        /// <param name="rect"></param>
        public void MouseClick(List<RECT> rect)
        {
            Random rnd = new Random();
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
                Thread.Sleep(rnd.Next(500, 800));
            }
        }
    }

}
