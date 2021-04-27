using Shipwreck.Phash;
using Shipwreck.Phash.Bitmaps;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CSharpAPIsDemo;

namespace Main.Service
{
    /// <summary>
    /// 执行任务
    /// </summary>
    public class TaskExcuteService : ImagePhash
    {
        bool state { get; set; } = false;
        public ConcurrentDictionary<int, Digest> keyValuePairs = new();

        /// <summary>
        /// 任务开始,比较两张图片的相似度
        /// 默认值90%
        /// </summary>
        /// <returns></returns>
        public bool StartTask(WindowInfo[] windowsList)
        {
            //比较两张图片的评分
            float score = 0;
            var list = windowsList.ToList();
            for (int i = 0; i < list.Count; i++)
            {
                ////获取图片
                Bitmap image = (Bitmap)MouseHookHelper.Capture(list[i].hWnd);

                //SimilarPhoto similarPhoto = new ();
                //Image mainImage = null;
                //获取游戏图片的哈希
                //string gameHash = SimilarPhoto.GetHash(image);
                var gameHash = ComputeDigest(image.ToLuminanceImage());
                var hash = GetMainPic(i);
                score = ImagePhash.GetCrossCorrelation(gameHash, hash);
            }
            //默认值90%
            return score > DEFAULT_THRESHOLD;
        }

        public Digest GetMainPic(int id)
        {
            if (!keyValuePairs.TryGetValue(id, out Digest hash))
            {
                //Image mainImage = null;
                Bitmap bitmap = null;
                //第一张
                if (id == 0)
                {
                    //mainImage = SimilarPhoto.GetImage(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images\\1.png"));
                     bitmap = (Bitmap)Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images\\1.png"));
                }
                if (id == 1)
                {
                    //mainImage = SimilarPhoto.GetImage(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images\\2.png"));
                     bitmap = (Bitmap)Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images\\2.png"));
                }
                if (id == 2)
                {
                    //mainImage = SimilarPhoto.GetImage(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images\\3.png"));
                     bitmap = (Bitmap)Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images\\3.png"));
                }
                //value = SimilarPhoto.GetHash(mainImage);
                //var bitmap = (Bitmap)Image.FromFile(fullPathToImage);

                hash = ImagePhash.ComputeDigest(bitmap.ToLuminanceImage());
                //var score = ImagePhash.GetCrossCorrelation(hash1, hash2);
                keyValuePairs.TryAdd(id, hash);
            }
            return hash;
        }
    }
}
