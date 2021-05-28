using Main.Enum;
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
        //public static ConcurrentDictionary<int, Digest> keyValuePairs { get; set; } = new();
        public static ConcurrentDictionary<string, Digest> keyValueGameType { get; set; } = new();


        #region 感知哈希算法
        /// <summary>
        /// 任务开始,比较两张图片的相似度
        /// 默认值90%
        /// 感知哈希
        /// </summary>
        /// <param name="imageList"></param>
        /// <param name="gameType"></param>
        /// <returns></returns>
        public static bool StartTaskForPHash(List<Bitmap> imageList, GameType gameType)
        {
            bool state = true;

            for (int i = 0; i < imageList.Count; i++)
            {
                //比较两张图片的评分
                float score;
                //////获取图片
                //using Bitmap image = (Bitmap)MouseHookHelper.Capture(list[i].hWnd);

                //SimilarPhoto similarPhoto = new ();
                //Image mainImage = null;
                //获取游戏图片的哈希
                var gameHash = ComputeDigest(imageList[i].ToLuminanceImage());
                //string gameHash = SimilarPhoto.GetHash(image);
                var hash = GetMainPic(i,gameType);
                score = GetCrossCorrelation(gameHash, hash);
                //如果低于70%
                if (score < 0.7f)
                {
                    state = false;
                }
            }
            //默认值90%
            //return score > DEFAULT_THRESHOLD;
            return state;
        }


        /// <summary>
        /// 获取参照图
        /// </summary>
        /// <param name="id"></param>
        /// <param name="gameType"></param>
        /// <returns></returns>
        public static Digest GetMainPic(int id, GameType gameType)
        {
            if (!keyValueGameType.TryGetValue($"{gameType}_{id}", out Digest hash))
            {
                if (gameType == GameType.yu)
                {
                    using var bitmap = (Bitmap)Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"Images\\MainImage\\{id + 1}.png"));
                    hash = ComputeDigest(bitmap.ToLuminanceImage());

                }
                if (gameType == GameType.ling)
                {
                    using var bitmap = (Bitmap)Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images\\yuling\\1.png"));
                    hash = ComputeDigest(bitmap.ToLuminanceImage());
                }
                if (gameType == GameType.ye)
                {
                    using var bitmap = (Bitmap)Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images\\yeyuanhuo\\1.png"));
                    hash = ComputeDigest(bitmap.ToLuminanceImage());
                }

                keyValueGameType.TryAdd($"{gameType}_{id}", hash);
            }

            return hash;
        }

        #endregion


        #region 均值哈希算法

        /// <summary>
        /// 任务开始,比较两张图片的相似度
        /// 均值哈希
        /// </summary>
        /// <param name="windowsList"></param>
        /// <returns></returns>
        public static bool StartTaskForAHash(List<Image> imageList)
        {
            bool state = false;
 
            for (int i = 0; i < imageList.Count; i++)
            {
                ////获取图片
                Image image = imageList[i];
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


        public static string GetMainPicForAHash(int id)
        {

            Image mainImage = null;
            //Bitmap bitmap = null;
            //第一张
            if (id == 0)
            {
                mainImage = SimilarPhoto.GetImage(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images\\MainImage\\1.png"));

            }
            if (id == 1)
            {
                mainImage = SimilarPhoto.GetImage(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images\\MainImage\\2.png"));

            }
            if (id == 2)
            {
                mainImage = SimilarPhoto.GetImage(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images\\MainImage\\3.png"));

            }
            var value = SimilarPhoto.GetHash(mainImage);
            //var bitmap = (Bitmap)Image.FromFile(fullPathToImage);


            //var score = ImagePhash.GetCrossCorrelation(hash1, hash2);
            //keyValuePairs.TryAdd(id, hash);

            return value;
        }


        #endregion






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
