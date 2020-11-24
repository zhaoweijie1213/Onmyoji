using AForge.Imaging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Service
{
    public static class ImageMeanService
    {
        /// <summary>
        /// 判断图像是否存在
        /// </summary>
        /// <param name="template"></param>
        /// <param name="bmp"></param>
        /// <returns></returns>
        public static bool ContainsImg(this Bitmap template, Bitmap bmp)
        {
            // create template matching algorithm's instance // (set similarity threshold to 92.1%)
            ExhaustiveTemplateMatching tm = new ExhaustiveTemplateMatching(0.921f); // find all matchings with specified above similarity
            TemplateMatch[] matchings = tm.ProcessImage(template, bmp); // highlight found matchings

            return matchings.Length > 0;
        }
        /// <summary>
        /// 判断图像是否存在另外的图像中，并返回坐标
        /// </summary>
        /// <param name="template"></param>
        /// <param name="bmp"></param>
        /// <returns></returns>
        public static Point ContainsGetPoint(this Bitmap template, Bitmap bmp)
        {
          
            ExhaustiveTemplateMatching tm = new ExhaustiveTemplateMatching(0.921f);
            TemplateMatch[] matchings = tm.ProcessImage(template, bmp);
            BitmapData data = template.LockBits(new Rectangle(0, 0, template.Width, template.Height), ImageLockMode.ReadWrite, template.PixelFormat);
            Point p = new Point();

            if (matchings.Length > 0)
            {
                Drawing.Rectangle(data, matchings[0].Rectangle, Color.White);
                p = matchings[0].Rectangle.Location;
                template.UnlockBits(data);
            }

            return p;
        }
    }
}
