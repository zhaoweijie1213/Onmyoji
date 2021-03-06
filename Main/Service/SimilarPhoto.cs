﻿using System;
using System.IO;
using System.Drawing;

namespace Main.Service
{
    /// <summary>
    /// 相似的照片
    /// 均值哈希算法
    /// 现在已弃用,使用感知哈希算法
    /// </summary>
    public class SimilarPhoto
    {
        //Image SourceImg;

        public static Image GetImage(string filePath)
        {
            using var img = Image.FromFile(filePath);
            return img;
        }

        //public SimilarPhoto(Stream stream)
        //{
        //    SourceImg = Image.FromStream(stream);
        //}


        /// <summary>
        /// 获取哈希
        /// </summary>
        /// <returns></returns>
        public static String GetHash(Image SourceImg)
        {
            using Image image = ReduceSize(SourceImg);
            Byte[] grayValues = ReduceColor(image);
            Byte average = CalcAverage(grayValues);
            String reslut = ComputeBits(grayValues, average);

            return reslut;
        }

        /// <summary>
        /// Step 1 : Reduce size to 8*8
        /// 将图片变为8X8像素
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        private static Image ReduceSize(Image SourceImg,int width = 8, int height = 8)
        {
            Image image = SourceImg.GetThumbnailImage(width, height, () => { return false; }, IntPtr.Zero);
            return image;
        }


        /// <summary>
        /// Step 2 : Reduce Color
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        private static Byte[] ReduceColor(Image image)
        {
            Bitmap bitMap = new(image);
            Byte[] grayValues = new Byte[image.Width * image.Height];

            for (int x = 0; x < image.Width; x++)
                for (int y = 0; y < image.Height; y++)
                {
                    Color color = bitMap.GetPixel(x, y);
                    byte grayValue = (byte)((color.R * 30 + color.G * 59 + color.B * 11) / 100);
                    grayValues[x * image.Width + y] = grayValue;
                }
            return grayValues;
        }

        /// <summary>
        /// Step 3 : Average the colors
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        private static Byte CalcAverage(byte[] values)
        {
            int sum = 0;
            for (int i = 0; i < values.Length; i++)
                sum += (int)values[i];
            return Convert.ToByte(sum / values.Length);
        }

        /// <summary>
        ///  Step 4 : Compute the bits
        /// </summary>
        /// <param name="values"></param>
        /// <param name="averageValue"></param>
        /// <returns></returns>
        private static string ComputeBits(byte[] values, byte averageValue)
        {
            char[] result = new char[values.Length];
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] < averageValue)
                    result[i] = '0';
                else
                    result[i] = '1';
            }
            return new String(result);
        }

        /// <summary>
        /// Compare hash
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int CalcSimilarDegree(string a, string b)
        {
            if (a.Length != b.Length)
                return -1;
            int count = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                    count++;
            }
            return count;
        }

        public static bool GetResult(string a, string b)
        {
            var count = CalcSimilarDegree(a, b);
            if (count==-1)
            {
                return false;
            }
            return count <= 5;
        }
    }
}