using Main.Models;
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
        public bool mouseClick { get; set; } = false;
        //队长
        public  decimal RspXmin = 842/921;
        public  decimal RspXmax = 905/ 921;

        public  decimal RspYmin = 455 / 549;
        public  decimal RspYmax = 518 / 549; 
        //成员
        public  decimal LspXmin = (decimal)0.091;
        public  decimal LspXmax = 179/ 898;

        public  decimal LspYmin = 112 / 536;
        public  decimal LspYmax = 344 / 536;

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
            PointRange rpoint = new PointRange();
            rpoint.MinX= (decimal)842 / (decimal)921;
            rpoint.MaxX= (decimal)905 / (decimal)921;
            rpoint.MinY= (decimal)455 / (decimal)549;
            rpoint.MaxY= (decimal)518 / (decimal)549;
            PointRange lpoint = new PointRange();
            lpoint.MinX = (decimal)71 / (decimal)787;
            lpoint.MaxX = (decimal)179 / (decimal)898;
            lpoint.MinY = (decimal)112 / (decimal)536;
            lpoint.MaxY = (decimal)344 / (decimal)536;


            while (mouseClick)
            {
                Random rnd = new Random();
                foreach (var item in rect)
                {
                    int windowsWidth = item.Right - item.Left;
                    int windowsHeight = item.Bottom - item.Top;
                    int X = 0;
                    int Y = 0;
                    if (rect.IndexOf(item)==0)
                    {
                        X = item.Left + rnd.Next(windowsWidth * (int)(rpoint.MinX * 10000)/10000, windowsWidth * (int)(rpoint.MaxX * 10000)/10000);
                        Y = item.Top + rnd.Next(windowsHeight * (int)(rpoint.MinY * 10000)/10000, windowsHeight * (int)(rpoint.MaxY * 10000)/10000);
                        MouseHookHelper.LeftMouseClick(new MouseHookHelper.POINT()
                        {
                            X = X,
                            Y = Y
                        });
                    }
                    else
                    {
                        X = item.Left + rnd.Next(windowsWidth * (int)(lpoint.MinX * 10000) / 10000, windowsWidth * (int)(lpoint.MaxX * 10000) / 10000);
                        Y = item.Top + rnd.Next(windowsHeight * (int)(lpoint.MinY * 10000) / 10000, windowsHeight * (int)(lpoint.MaxY * 10000) / 10000);
                        MouseHookHelper.LeftMouseClick(new MouseHookHelper.POINT()
                        {
                            X = X,
                            Y = Y
                        });
                    }
                    Thread.Sleep(rnd.Next(500, 800));
                }
                Thread.Sleep(3000);
            }
          
        }
    }

}
