using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Service
{
    public class EventService
    {
        /// <summary>
        /// 保存图片
        /// </summary>
        public static void SaveImage(Image img)
        {
            using (Bitmap bmp = new Bitmap(img)) //将文件转为流
            {
                bmp.RotateFlip(RotateFlipType.Rotate90FlipNone);
                Image image = bmp;
                string fileName = Guid.NewGuid().ToString().ToUpper() + ".png";
                //string fileName = DateTime.Now.Ticks.ToString() + random + ".png";
                //获取项目wwwroot目录
                //string path = AppDomain.CurrentDomain.BaseDirectory;
                string path = Readjson("imagePath");
                //配置文件目录
                string directoryPath = path + "";
                if (!Directory.Exists(directoryPath))//如果路径不存在
                {
                    Directory.CreateDirectory(directoryPath);//创建一个路径的文件夹
                }
                string Path = directoryPath + fileName;
                //save方法路径不存在会报错
                img.Save(Path, ImageFormat.Png);
            }
        }
        /// <summary>
        /// 读取JSON文件
        /// </summary>
        /// <param name="key">JSON文件中的key值</param>
        /// <returns>JSON文件中的value值</returns>
        public static string Readjson(string key)
        {
            string jsonfile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.json");//JSON文件路径

            using (StreamReader file = File.OpenText(jsonfile))
            {
                using (JsonTextReader reader = new JsonTextReader(file))
                {
                    JObject o = (JObject)JToken.ReadFrom(reader);
                    var value = o[key].ToString();
                    return value;
                }
            }
        }
    }
}
