using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DolPicCrawler.XmlHashTag
{
    /// <summary>
    /// 클래스 enum 타입
    /// </summary>
    public enum OriginSiteType
    {
        twitter, 
        instagram
    }

    public abstract class XmlMake
    {
        public abstract void XmlListMake(ref List<int> no, ref List<string> tag);

        /// <summary>
        /// 객체 생성 팩토리 클래스
        /// </summary>
        /// <param name="siteType">생성 클래스 타입</param>
        /// <returns></returns>
        public static XmlMake XmlFactory(OriginSiteType siteType)
        {
            switch (siteType)
            {
                case OriginSiteType.twitter:
                    return new TwitterXmlMake();

                case OriginSiteType.instagram:
                    return new InstagramXmlMake();
            }

            throw new System.NotSupportedException("The OriginSiteType " + siteType.ToString() + " is not recognized.");
        }
    }
}
