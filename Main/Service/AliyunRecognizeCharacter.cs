using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Exceptions;
using Aliyun.Acs.Core.Http;
using Aliyun.Acs.Core.Profile;
using AlibabaCloud.RPCClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Service
{
    public  class AliyunRecognizeCharacter
    {
        /// <summary>
        /// 阿里云通用文字识别
        /// </summary>
        public  void GetChart()
        {
            IClientProfile profile = DefaultProfile.GetProfile("cn-shanghai", "<accessKeyId>", "<accessSecret>");
            DefaultAcsClient client = new DefaultAcsClient(profile);
            CommonRequest request = new CommonRequest
            {
                Method = MethodType.POST,
                Domain = "ocr.cn-shanghai.aliyuncs.com",
                Version = "2019-12-30",
                Action = "RecognizeCharacter"
            };
            // request.Protocol = ProtocolType.HTTP;
            request.AddQueryParameters("ImageURL", "http://explorer-image.oss-cn-shanghai.aliyuncs.com/1652898910756959/8B158CD2-6891-417E-8D1F-D0424E87936B.png?");
            request.AddQueryParameters("MinHeight", "590");
            request.AddQueryParameters("OutputProbability", "true");
            try
            {
                CommonResponse response = client.GetCommonResponse(request);
                Console.WriteLine(System.Text.Encoding.Default.GetString(response.HttpResponse.Content));
                
            }
            catch (ServerException e)
            {
                Console.WriteLine(e);
            }
            catch (ClientException e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
