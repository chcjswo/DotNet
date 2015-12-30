using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;

namespace DolPicCrawler.Image
{
    public class ImageService
    {
        private static readonly ImageService _imageService;
        //private const string CON_IMAGE_SEND_URL = "http://localhost:3281/api/DolPicImg/";
        //private const string CON_IMAGE_DELETE_URL = "http://localhost:3281/Pics/DolPicNoImageDelete/";
        private const string CON_IMAGE_SEND_URL = "http://www.dolpic.kr/api/DolPicImg/";
        private const string CON_IMAGE_DELETE_URL = "http://www.dolpic.kr/Pics/DolPicNoImageDelete/";

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
        /// <param name="a_nTagUrlType">사이트 타입 1:트위터 2:인스타그램 3:페이스북</param>
        public void ImageSend(Dictionary<int, List<string>> a_dImage, int a_nTagUrlType)
        {
            using (var client = new HttpClient())
            {
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
                            TagUrlType = a_nTagUrlType,
                            IsView = 1
                        }, new JsonMediaTypeFormatter()).Result;

                        Console.WriteLine("url == " + string.Format(CON_IMAGE_SEND_URL, kvp.Key, sBase64, a_nTagUrlType, 1));
                        Console.WriteLine("TagNo == " + kvp.Key);
                        Console.WriteLine("ImageSrc == " + sBase64);
                    }
                }
            }
        }
        #endregion

        #region 이미지 삭제하기
        /// <summary>
        /// 이미지 저장하고 바로 호출
        /// </summary>
        public void ImageDelete()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.ExpectContinue = false;
                var result = client.PostAsync(CON_IMAGE_DELETE_URL,
                new
                {
                }, new JsonMediaTypeFormatter()).Result;
            }
        }
        #endregion

        private ImageService() { }
    }
}
