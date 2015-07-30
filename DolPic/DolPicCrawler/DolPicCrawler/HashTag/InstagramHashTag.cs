using System.Collections.Generic;
using System.Xml;

namespace DolPicCrawler.HashTag
{
    public class InstagramHashTag : OriginHashTag
    {
        /// <summary>
        /// 인스타그램 해쉬태그 xml문서가 있는 주소
        /// </summary>
        private const string CON_XML_URL = "http://www.dolpic.kr/twitter_image.xml";
        /// <summary>
        /// XML 노드
        /// </summary>
        private const string CON_XML_NODE = "/twitter/images";

        public override void XmlListMake(ref List<int> _listNo, ref List<string> _listInstagramHashTag)
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
    }
}
