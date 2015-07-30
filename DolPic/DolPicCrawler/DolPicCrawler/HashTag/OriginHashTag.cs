using System.Collections.Generic;

namespace DolPicCrawler.HashTag
{
    /// <summary>
    /// 클래스 enum 타입
    /// </summary>
    public enum OriginSiteType
    {
        twitter, 
        instagram,
        facebook
    }

    public abstract class OriginHashTag
    {
        /// <summary>
        /// 해당 사이트 XML 리스트 만들기
        /// </summary>
        /// <param name="no">해쉬태그 고유번호</param>
        /// <param name="tag">해쉬태그</param>
        public abstract void XmlListMake(ref List<int> no, ref List<string> tag);


        //public abstract void ImageSrcSearch(ref List<int> no, ref List<string> tag);

        /// <summary>
        /// 객체 생성 팩토리 클래스
        /// </summary>
        /// <param name="siteType">생성 클래스 타입</param>
        /// <returns></returns>
        public static OriginHashTag XmlFactory(OriginSiteType siteType)
        {
            switch (siteType)
            {
                case OriginSiteType.twitter:
                    return new TwitterHashTag();

                case OriginSiteType.instagram:
                    return new InstagramHashTag();

                case OriginSiteType.facebook:
                    return new FacebookHashTag();
            }

            throw new System.NotSupportedException("The OriginSiteType " + siteType.ToString() + " is not recognized.");
        }
    }
}
