using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;

namespace DolPicCrawler.Image
{
    public class ImageService
    {
        private static readonly ImageService _imageService;
        //private const string CON_IMAGE_SEND_URL = "http://localhost:3281/api/DolPicImg/";
        private const string CON_IMAGE_SEND_URL = "http://www.dolpic.kr/api/DolPicImg/";

        /// <summary>
        /// static 초기화
        /// </summary>
        static ImageService()
        {
            _imageService = new ImageService();
        }

        public static ImageService getInstance
        {
            get
            {
                return _imageService;
            }
        }

        #region 이미지 저장하기

        /// <summary>
        /// 이미지 저장하기
        /// </summary>
        /// <param name="a_dImage">저장할 이미지 정보 Dictionary</param>
        public void ImageSend(Dictionary<int, List<string>> a_dImage)
        {
            var TagUrlType = 1;
            using (var client = new HttpClient())
            {
                //client.DefaultRequestHeaders.ExpectContinue = false;

                foreach (KeyValuePair<int, List<string>> kvp in a_dImage)
                {
                    Console.WriteLine("Key: " + kvp.Key);
                    Console.WriteLine("Value: " + kvp.Value);

                    foreach (var item in kvp.Value)
                    {
                        // Bsee64 인코딩
                        var sBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(item));

                        var result = client.PostAsync(CON_IMAGE_SEND_URL,
                        new
                        {
                            TagNo = kvp.Key,
                            ImageSrc = sBase64,
                            TagUrlType = TagUrlType,
                            IsView = 1
                        }, new JsonMediaTypeFormatter()).Result;

                        Console.WriteLine("url == " + string.Format(CON_IMAGE_SEND_URL, kvp.Key, sBase64, TagUrlType, 1));

                        //요청을 보내고 응답을 받는다
                        //response = request.GetResponse();

                        Console.WriteLine("TagNo == " + kvp.Key);
                        Console.WriteLine("ImageSrc == " + sBase64);
                    }
                }
            }
        }

        #endregion

        private ImageService() { }
    }
}
