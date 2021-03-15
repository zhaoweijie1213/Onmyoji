using Main.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
        ////队长
        //public  decimal RspXmin = 842/921;
        //public  decimal RspXmax = 905/ 921;

        //public  decimal RspYmin = 455 / 549;
        //public  decimal RspYmax = 518 / 549; 
        ////成员
        //public  decimal LspXmin = (decimal)0.091;
        //public  decimal LspXmax = 179/ 898;

        //public  decimal LspYmin = 112 / 536;
        //public  decimal LspYmax = 344 / 536;

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
                GetWindowRect(item.hWnd, ref sp);
                rect.Add(sp);
            }
            return rect;
        }
        public void MouseClick(List<RECT> rect)
        {
            //右边区域
            PointRange rpoint = new PointRange
            {
                MinX = 914,
                MaxX = 982,
                MinY = 829,
                MaxY = 943
            };
            //左边区域
            PointRange lpoint = new PointRange
            {
                MinX = 095,
                MaxX = 200,
                MinY = 210,
                MaxY = 641
            };
            if (rect.Count == 1)
            {
                //while (mouseClick)
                //{
                    OneClick(rect, rpoint);
                //}
            }
            if (rect.Count == 2)
            {
                //while (mouseClick)
                //{
                    TwoClick(rect, rpoint, lpoint);
                //}
                
            }
            if (rect.Count == 3)
            {
                //while (mouseClick)
                //{
                    ThreeClick(rect, rpoint, lpoint);
                //}
            }


        }

        /// <summary>
        /// 全左边区域
        /// </summary>
        /// <param name="rect"></param>
        public void SecondMouseClick(List<RECT> rect)
        {
            //右边区域                                                                                                                                                                                                                                                                                                                                                                                                                                                            
            PointRange rpoint = new PointRange
            {
                MinX = 914,
                MaxX = 982,
                MinY = 829,
                MaxY = 943
            };
            //左边区域
            PointRange lpoint = new PointRange
            {
                MinX = 095,
                MaxX = 200,
                MinY = 210,
                MaxY = 641
            };
            if (rect.Count == 1)
            {
                OneClick(rect, rpoint);
            }
            if (rect.Count == 2)
            {
            
                SecondTwoClick(rect, rpoint, lpoint);
            }
            if (rect.Count == 3)
            {
                SecondThreeClick(rect, rpoint, lpoint);
            }


        }

        public void OneClick(List<RECT> rect, PointRange rpoint)
        {
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            //var item = rect[0];
            int windowsWidth1 = rect[0].Right - rect[0].Left;
            int windowsHeight1 = rect[0].Bottom - rect[0].Top;

            //int windowsWidth2 = rect[1].Right - rect[1].Left;
            //int windowsHeight2 = rect[1].Bottom - rect[1].Top;

            int firstX = rect[0].Left + rnd.Next(windowsWidth1 * (int)(rpoint.MinX) / 1000, windowsWidth1 * (int)(rpoint.MaxX) / 1000);
            int firstY = rect[0].Top + rnd.Next(windowsHeight1 * (int)(rpoint.MinY) / 1000, windowsHeight1 * (int)(rpoint.MaxY) / 1000);
            //第一个
            MouseHookHelper.LeftMouseClick(new MouseHookHelper.POINT()
            {
                X = firstX,
                Y = firstY
            });
            //Thread.Sleep(1000);
        }

        public void TwoClick(List<RECT> rect, PointRange rpoint, PointRange lpoint)
        {

            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            //var item = rect[0];
            int windowsWidth1 = rect[0].Right - rect[0].Left;
            int windowsHeight1 = rect[0].Bottom - rect[0].Top;   

            int windowsWidth2 = rect[1].Right - rect[1].Left;
            int windowsHeight2 = rect[1].Bottom - rect[1].Top;

            int firstX = rect[0].Left + rnd.Next(windowsWidth1 * (int)(rpoint.MinX) / 1000, windowsWidth1 * (int)(rpoint.MaxX) / 1000);
            int firstY = rect[0].Top + rnd.Next(windowsHeight1 * (int)(rpoint.MinY) / 1000, windowsHeight1 * (int)(rpoint.MaxY) / 1000);

            int seconedX = rect[1].Left + rnd.Next(windowsWidth2 * (int)(lpoint.MinX) / 1000, windowsWidth2 * (int)(lpoint.MaxX) / 1000);
            int seconedY = rect[1].Top + rnd.Next(windowsHeight2 * (int)(lpoint.MinY) / 1000, windowsHeight2 * (int)(lpoint.MaxY) / 1000);
            Thread.Sleep(3000);
            //第一个
            LeftMouseClick(new POINT()
            {
                X = firstX,
                Y = firstY
            });
            //第二个
            LeftMouseClick(new POINT()
            {
                X = seconedX,
                Y = seconedY
            });
            Thread.Sleep(rnd.Next(200, 300));
            LeftMouseClick(new POINT()
            {
                X = seconedX,
                Y = seconedY
            });
        }
        public void ThreeClick(List<RECT> rect, PointRange rpoint, PointRange lpoint)
        {
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            //var item = rect[0];
            int windowsWidth1 = rect[0].Right - rect[0].Left;
            int windowsHeight1 = rect[0].Bottom - rect[0].Top;

            int windowsWidth2 = rect[1].Right - rect[1].Left;
            int windowsHeight2 = rect[1].Bottom - rect[1].Top;

            int windowsWidth3 = rect[2].Right - rect[2].Left;
            int windowsHeight3 = rect[2].Bottom - rect[2].Top;

            int firstX = rect[0].Left + rnd.Next(windowsWidth1 * (int)(rpoint.MinX) / 1000, windowsWidth1 * (int)(rpoint.MaxX) / 1000);
            int firstY = rect[0].Top + rnd.Next(windowsHeight1 * (int)(rpoint.MinY) / 1000, windowsHeight1 * (int)(rpoint.MaxY) / 1000);

            int seconedX = rect[1].Left + rnd.Next(windowsWidth2 * (int)(lpoint.MinX) / 1000, windowsWidth2 * (int)(lpoint.MaxX) / 1000);
            int seconedY = rect[1].Top + rnd.Next(windowsHeight2 * (int)(lpoint.MinY) / 1000, windowsHeight2 * (int)(lpoint.MaxY) / 1000);

            int ThirdX = rect[2].Left + rnd.Next(windowsWidth3 * (int)(lpoint.MinX) / 1000, windowsWidth3 * (int)(lpoint.MaxX) / 1000);
            int ThirdY = rect[2].Top + rnd.Next(windowsHeight3 * (int)(lpoint.MinY) / 1000, windowsHeight3 * (int)(lpoint.MaxY) / 1000);

            Thread.Sleep(3000);
            //第一个
            LeftMouseClick(new POINT()
            {
                X = firstX,
                Y = firstY
            });
            Thread.Sleep(rnd.Next(200, 300));
            //第二个
            LeftMouseClick(new POINT()
            {
                X = seconedX,
                Y = seconedY
            });
            Thread.Sleep(rnd.Next(200, 300));
            //LeftMouseClick(new POINT()
            //{
            //    X = seconedX,
            //    Y = seconedY
            //});
            //第三个
            LeftMouseClick(new POINT()
            {
                X = ThirdX,
                Y = ThirdY
            });
            //Thread.Sleep(rnd.Next(200, 300));
            //LeftMouseClick(new POINT()
            //{
            //    X = ThirdX,
            //    Y = ThirdY
            //});
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="rpoint"></param>
        /// <param name="lpoint"></param>
        public void SecondTwoClick(List<RECT> rect, PointRange rpoint, PointRange lpoint)
        {

            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            //var item = rect[0];
            int windowsWidth1 = rect[0].Right - rect[0].Left;
            int windowsHeight1 = rect[0].Bottom - rect[0].Top;

            int windowsWidth2 = rect[1].Right - rect[1].Left;
            int windowsHeight2 = rect[1].Bottom - rect[1].Top;

            int firstX = rect[0].Left + rnd.Next(windowsWidth1 * (int)(lpoint.MinX) / 1000, windowsWidth1 * (int)(lpoint.MaxX) / 1000);
            int firstY = rect[0].Top + rnd.Next(windowsHeight1 * (int)(lpoint.MinY) / 1000, windowsHeight1 * (int)(lpoint.MaxY) / 1000);

            int seconedX = rect[1].Left + rnd.Next(windowsWidth2 * (int)(lpoint.MinX) / 1000, windowsWidth2 * (int)(lpoint.MaxX) / 1000);
            int seconedY = rect[1].Top + rnd.Next(windowsHeight2 * (int)(lpoint.MinY) / 1000, windowsHeight2 * (int)(lpoint.MaxY) / 1000);
            Thread.Sleep(3000);
            //第一个
            LeftMouseClick(new POINT()
            {
                X = firstX,
                Y = firstY
            });
            //第二个
            LeftMouseClick(new POINT()
            {
                X = seconedX,
                Y = seconedY
            });
            Thread.Sleep(rnd.Next(200, 300));
            LeftMouseClick(new POINT()
            {
                X = seconedX,
                Y = seconedY
            });
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="rpoint"></param>
        /// <param name="lpoint"></param>
        public void SecondThreeClick(List<RECT> rect, PointRange rpoint, PointRange lpoint)
        {
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            //var item = rect[0];
            int windowsWidth1 = rect[0].Right - rect[0].Left;
            int windowsHeight1 = rect[0].Bottom - rect[0].Top;

            int windowsWidth2 = rect[1].Right - rect[1].Left;
            int windowsHeight2 = rect[1].Bottom - rect[1].Top;

            int windowsWidth3 = rect[2].Right - rect[2].Left;
            int windowsHeight3 = rect[2].Bottom - rect[2].Top;

            int firstX = rect[0].Left + rnd.Next(windowsWidth1 * (int)(lpoint.MinX) / 1000, windowsWidth1 * (int)(lpoint.MaxX) / 1000);
            int firstY = rect[0].Top + rnd.Next(windowsHeight1 * (int)(lpoint.MinY) / 1000, windowsHeight1 * (int)(lpoint.MaxY) / 1000);

            int seconedX = rect[1].Left + rnd.Next(windowsWidth2 * (int)(lpoint.MinX) / 1000, windowsWidth2 * (int)(lpoint.MaxX) / 1000);
            int seconedY = rect[1].Top + rnd.Next(windowsHeight2 * (int)(lpoint.MinY) / 1000, windowsHeight2 * (int)(lpoint.MaxY) / 1000);

            int ThirdX = rect[2].Left + rnd.Next(windowsWidth3 * (int)(lpoint.MinX) / 1000, windowsWidth3 * (int)(lpoint.MaxX) / 1000);
            int ThirdY = rect[2].Top + rnd.Next(windowsHeight3 * (int)(lpoint.MinY) / 1000, windowsHeight3 * (int)(lpoint.MaxY) / 1000);

            Thread.Sleep(3000);
            //第一个
            LeftMouseClick(new POINT()
            {
                X = firstX,
                Y = firstY
            });
            Thread.Sleep(rnd.Next(200, 300));
            //第二个
            LeftMouseClick(new POINT()
            {
                X = seconedX,
                Y = seconedY
            });
            Thread.Sleep(rnd.Next(200, 300));
            //LeftMouseClick(new POINT()
            //{
            //    X = seconedX,
            //    Y = seconedY
            //});
            //第三个
            LeftMouseClick(new POINT()
            {
                X = ThirdX,
                Y = ThirdY
            });
            //Thread.Sleep(rnd.Next(200, 300));
            //LeftMouseClick(new POINT()
            //{
            //    X = ThirdX,
            //    Y = ThirdY
            //});
        }
    }

}
