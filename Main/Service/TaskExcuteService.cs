using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CSharpAPIsDemo;

namespace Main.Service
{
    public class TaskExcuteService
    {
        bool state { get; set; } = false;
        /// <summary>
        /// 任务开始
        /// </summary>
        /// <returns></returns>
        public async Task StartTask()
        {

            CSharpAPIsDemo api = new CSharpAPIsDemo();
            //得到所有阴阳师的窗体
            var windowsList = api.GetAllDesktopWindows();
            if (windowsList.Length == 0)
            {

            }
            foreach (var item in windowsList)
            {
                ////获取图片
                Image image = MouseHookHelper.Capture(item.hWnd);

                SimilarPhoto similarPhoto = new SimilarPhoto();
                //获取游戏图片的哈希
                string gameHash = similarPhoto.GetHash(image);

                //Bitmap bmp = new Bitmap(image);
                //PicGetHelper.GetP(bmp);
            }
        }

        /// <summary>
        /// 任务开始
        /// </summary>
        /// <returns></returns>
        public bool StartTask(WindowInfo[] windowsList)
        {

            var list = windowsList.ToList();
            foreach (var item in list)
            {
                ////获取图片
                Image image = MouseHookHelper.Capture(item.hWnd);

                SimilarPhoto similarPhoto = new SimilarPhoto();
                Image mainImage = null;
                //获取游戏图片的哈希
                string gameHash = similarPhoto.GetHash(image);
                //第一张
                if (list.IndexOf(item) == 0)
                {
                    mainImage = similarPhoto.GetImage(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images\\1.png"));
                }
                if (list.IndexOf(item) == 1)
                {
                    mainImage = similarPhoto.GetImage(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images\\2.png"));
                }
                if (list.IndexOf(item) == 2)
                {
                    mainImage = similarPhoto.GetImage(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images\\3.png"));
                }
                string mainHash = similarPhoto.GetHash(mainImage);
                //Bitmap bmp = new Bitmap(image);
                //PicGetHelper.GetP(bmp);
                state = similarPhoto.GetResult(mainHash, gameHash);
            }


            return state;

            //if (task.IsCompleted)
            //{
            //    return state;
            //}
            //else
            //{

            //}
            //return state;
        }
    }
}
