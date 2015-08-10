using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Xml;

namespace DolPicCrawler.HashTag
{
    public class InstagramHashTag : OriginHashTag
    {
        /// <summary>
        /// 인스타그램 해쉬태그 xml문서가 있는 주소
        /// </summary>
        private const string CON_XML_URL = "http://www.dolpic.kr/instagram_image.xml";
        /// <summary>
        /// XML 노드
        /// </summary>
        private const string CON_XML_NODE = "/instagram/images";

        private const string CON_IMAGE_URL = "https://instagram.com/{0}";
        //private const string CON_IMAGE_URL = "https://instagram.com/explore/tags/{0}";
        
        private const string CON_MATCH_TAG = "\"display_src\":\"(?<ImageSrc>.*?)\".*?";

        /// <summary>
        /// xml 해쉬태그 리스트 만들기
        /// </summary>
        /// <param name="_listNo">해쉬태그 고유번호</param>
        /// <param name="_listTwitterHashTag">해쉬태그</param>
        public override void XmlListMake(ref List<int> _listNo, ref List<string> _listInstagramHashTag, ref Dictionary<int, string> _dHashTag)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(CON_XML_URL);

            // 접근할 노드
            XmlNodeList xnList = xml.SelectNodes(CON_XML_NODE);

            // 리스트 초기화
            _listNo = new List<int>(xnList.Count);
            _listInstagramHashTag = new List<string>(xnList.Count);

            foreach (XmlNode xn in xnList)
            {
                _listNo.Add(int.Parse(xn.Attributes["no"].Value));
                _listInstagramHashTag.Add(xn.Attributes["tag"].Value);
            }
        }

        /// <summary>
        /// 해당 사이트에서 이미지 경로 추출
        /// </summary>
        /// <param name="a_listNo">해쉬태그 고유번호</param>
        /// <param name="a_listInstagramHashTag">해쉬태그</param>
        /// <param name="a_dImage">이미지 정보 Dictionary</param>
        public override void ImageSrcSearch(List<int> a_listNo, List<string> a_listInstagramHashTag, ref Dictionary<int, List<string>> a_dImage)
        {
            //응답요청을 한다
            WebRequest request = null;
            WebResponse response = null;

            //스트림으로 받아온다
            Stream resStream = null;
            StreamReader resReader = null;

            var nLoopCnt = 0;

            // 해쉬 태그대로 검색
            foreach (var tag in a_listInstagramHashTag)
            {
                var nHashTagNo = a_listNo[nLoopCnt++];

                //URI로부터 요청을 생성한다
                request = WebRequest.Create(string.Format(CON_IMAGE_URL, tag));

                //요청을 보내고 응답을 받는다
                response = request.GetResponse();

                //응답을 스트림으로 얻어온다
                resStream = response.GetResponseStream();

                using (resReader = new StreamReader(resStream, System.Text.Encoding.Default))
                {
                    // 결과물에서 이미지 URL 추출
                    ImageSearch(resReader.ReadToEnd(), nHashTagNo, ref a_dImage);
                }
            }

            if (resReader != null) resReader.Close();
            if (response != null) response.Close();
        }

        /// <summary>
        /// 이미지 찾기
        /// </summary>
        /// <param name="resString">결과 스트링</param>
        private void ImageSearch(string resString, int a_nTagNo, ref Dictionary<int, List<string>> a_dImage)
        {
            // 이미지 찾기
            Regex re = new Regex(CON_MATCH_TAG, RegexOptions.IgnoreCase | RegexOptions.Singleline);

            List<string> ltImg = new List<string>();

            for (Match m = re.Match(resString); m.Success; m = m.NextMatch())
            {
                string sImageSrc = m.Groups["ImageSrc"].Value;

                ltImg.Add(sImageSrc.Replace("\\", ""));
            }

            // Dictionary 저장
            a_dImage.Add(a_nTagNo, ltImg);
        }
    }
}
