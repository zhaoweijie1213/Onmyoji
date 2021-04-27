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
        //bool state { get; set; } = false;
        public static ConcurrentDictionary<int, Digest> keyValuePairs { get; set; } = new();

        /// <summary>
        /// 任务开始,比较两张图片的相似度
        /// 默认值90%
        /// 感知哈希
        /// </summary>
        /// <returns></returns>
        public bool StartTaskForPHash(WindowInfo[] windowsList)
        {
            //比较两张图片的评分
            float score = 0;
            var list = windowsList.ToList();
            for (int i = 0; i < list.Count; i++)
            {
                ////获取图片
                using Bitmap image = (Bitmap)MouseHookHelper.Capture(list[i].hWnd);

                //SimilarPhoto similarPhoto = new ();
                //Image mainImage = null;
                //获取游戏图片的哈希
                //string gameHash = SimilarPhoto.GetHash(image);
                var gameHash = ComputeDigest(image.ToLuminanceImage());
                var hash = GetMainPic(i);
                score = ImagePhash.GetCrossCorrelation(gameHash, hash);

            }
            //默认值90%
            //return score > DEFAULT_THRESHOLD;
            return score > 0.8f;
        }

        /// <summary>
        /// 任务开始,比较两张图片的相似度
        /// 均值哈希
        /// </summary>
        /// <param name="windowsList"></param>
        /// <returns></returns>
        public bool StartTaskForAHash(WindowInfo[] windowsList)
        {
            bool state = false;
 
            var list = windowsList.ToList();
            for (int i = 0; i < list.Count; i++)
            {
                ////获取图片
                using Image image = MouseHookHelper.Capture(list[i].hWnd);
                //SimilarPhoto similarPhoto = new ();
                //Image mainImage = null;
                //获取游戏图片的哈希
                string gameHash = SimilarPhoto.GetHash(image);
                var mainHash = GetMainPicForAHash(i);
                state=SimilarPhoto.GetResult(gameHash, mainHash);
            }
            //默认值90%
            //return score > DEFAULT_THRESHOLD;
            return state;
        }

        public Digest GetMainPic(int id)
        {
            if (!keyValuePairs.TryGetValue(id, out Digest hash))
            {
                //Image mainImage = null;
                //Bitmap bitmap = null;
                //第一张
                if (id == 0)
                {
                    //mainImage = SimilarPhoto.GetImage(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images\\1.png"));
                    using var bitmap = (Bitmap)Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images\\MainImage\\1.png"));
                    hash = ComputeDigest(bitmap.ToLuminanceImage());
                }
                if (id == 1)
                {
                    //mainImage = SimilarPhoto.GetImage(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images\\2.png"));
                    using var bitmap = (Bitmap)Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images\\MainImage\\2.png"));
                    hash = ComputeDigest(bitmap.ToLuminanceImage());
                }
                if (id == 2)
                {
                    //mainImage = SimilarPhoto.GetImage(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images\\3.png"));
                    using var bitmap = (Bitmap)Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images\\MainImage\\3.png"));
                    hash = ComputeDigest(bitmap.ToLuminanceImage());
                }
                //value = SimilarPhoto.GetHash(mainImage);
                //var bitmap = (Bitmap)Image.FromFile(fullPathToImage);

             
                //var score = ImagePhash.GetCrossCorrelation(hash1, hash2);
                keyValuePairs.TryAdd(id, hash);
            }
            return hash;
        }

        public string GetMainPicForAHash(int id)
        {

            Image mainImage = null;
            //Bitmap bitmap = null;
            //第一张
            if (id == 0)
            {
                mainImage = SimilarPhoto.GetImage(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images\\1.png"));

            }
            if (id == 1)
            {
                mainImage = SimilarPhoto.GetImage(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images\\2.png"));

            }
            if (id == 2)
            {
                mainImage = SimilarPhoto.GetImage(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images\\3.png"));

            }
            var value = SimilarPhoto.GetHash(mainImage);
            //var bitmap = (Bitmap)Image.FromFile(fullPathToImage);


            //var score = ImagePhash.GetCrossCorrelation(hash1, hash2);
            //keyValuePairs.TryAdd(id, hash);

            return value;
        }

        /// <summary>
        /// 测试方法
        /// </summary>
        /// <returns></returns>
        public static bool PHasTest()
        {
            using var bitmap = (Bitmap)Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images\\MainImage\\1.png"));
            //var bitmap = (Bitmap)Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images\\MainImage\\1.png"));
            var bitmap2 = (Bitmap)Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images\\MainImage\\1.png"));

            var hash = ImagePhash.ComputeDigest(bitmap.ToLuminanceImage());
            var hash1 = ImagePhash.ComputeDigest(bitmap2.ToLuminanceImage());

            var score = ImagePhash.GetCrossCorrelation(hash, hash1);
            return score >= 0.9f;
        }
    }
}
