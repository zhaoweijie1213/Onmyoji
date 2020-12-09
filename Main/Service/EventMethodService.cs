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
        public void MouseClick()
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
        }
    }

}
