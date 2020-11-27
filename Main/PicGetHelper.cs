using Main.Service;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tesseract;

namespace Main
{
    /// <summary>
    /// 图片
    /// </summary>
    public static class PicGetHelper
    {
        public static void GetP(Bitmap img)
        {
            using (var ocr = new TesseractEngine(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tessdata"), "chi_sim", EngineMode.Default))
            {
                var image = ImageWordService.ToBlackWhite(img);
                //保存图片
                EventService.SaveImage(image);
                var page = ocr.Process(image);
            }
        }
    }

}
