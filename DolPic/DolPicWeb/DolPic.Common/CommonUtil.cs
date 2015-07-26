using System.Text;

namespace DolPic.Common
{
    public class CommonUtil
    {
        /// <summary>
        /// Referrer 체크
        /// </summary>
        /// <returns></returns>
        public static bool CheckReferrer(string a_sReferUrl, string a_sCheckUrl)
        {
            if (a_sReferUrl.IndexOf(a_sCheckUrl) == 0)
                return true;

            return false;
        }

        #region 바로가기 페이지 목록 만들기

        /// <summary>
        /// 바로가기 페이지 목록 만들기
        /// </summary>
        /// <param name="a_nCurPage">현재 페이지</param>
        /// <param name="a_nRecCnt">레코드 수</param>
        /// <param name="a_nPageSize">한페이지에 보여줄 페이지 수</param>
        /// <param name="a_nViewPageCnt">바로가기에 보여줄 페이지 수</param>
        /// <returns>바로가기목록</returns>
        public static string GetGotoPageList(int a_nCurPage, int a_nRecCnt, int a_nPageSize, int a_nViewPageCnt)
        {
            StringBuilder sbPage = new StringBuilder();

            //바로가기 첫페이지 계산
            int nStartPage = ((a_nCurPage - 1) / a_nViewPageCnt) * a_nViewPageCnt + 1;
            // 전체 페이지수 계산
            int nPageCnt = (a_nRecCnt - 1) / a_nPageSize + 1;
            // 블럭페이지 계산
            int nBlockPage = ((a_nCurPage - 1) / a_nViewPageCnt) * a_nViewPageCnt + 1;

            if (nBlockPage != 1)
                sbPage.AppendFormat("<li page='{0}'><</li>&nbsp", nBlockPage - a_nViewPageCnt);

            int nCnt = 1;
            while (nStartPage <= nPageCnt && nCnt <= a_nViewPageCnt)
            {
                if (nStartPage == a_nCurPage)
                    sbPage.AppendFormat("<li page='{0}' class='on'>{0}</li>&nbsp;", nStartPage);
                else
                    sbPage.AppendFormat("<li page='{0}'>{0}</li>&nbsp;", nStartPage);

                nStartPage++;
                nCnt++;
                nBlockPage++;
            }

            if (nBlockPage < nPageCnt)
                sbPage.AppendFormat("<li page='{0}'>></li>", nBlockPage);

            return sbPage.ToString();
        }

        #endregion
    }
}
