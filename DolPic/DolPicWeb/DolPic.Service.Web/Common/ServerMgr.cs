
using DolPic.Biz.DolPicAdmin;
using DolPic.Data.Daos;
using DolPic.Data.Vos;
using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;

namespace DolPic.Service.Web.Common
{
    /// <summary>
    /// 서버가 실행되면 실행
    /// </summary>
    public class ServerMgr
    {
        protected static ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static readonly ServerMgr _Inst = new ServerMgr();
        public static ServerMgr Inst { get { return _Inst; } }

        private ServerMgr()
        {
        }

        public void Init()
        {
            // create a delegate of MethodInvoker poiting to
            // our Foo function.
            MethodInvoker simpleDelegate = new MethodInvoker(DailyCheck);

            // Calling Foo Async
            simpleDelegate.BeginInvoke(null, null);
        }

        public void Fin()
        {

        }

        public delegate void MethodInvoker();

        private void DailyCheck()
        {
            while (true)
            {
                int year = DateTime.Now.Year;
                var month = DateTime.Now.Month;
                var day = DateTime.Now.Date;

                //if (Convert.ToDateTime(string.Format("{0}-{1}-{2} 17:45:00")) <= DateTime.Now)
                //{
                //    log.DebugFormat("year == ", year);
                //    log.DebugFormat("month == ", month);
                //    log.DebugFormat("day == ", day);
                //}

                DeleteEmptyImage();

                log.DebugFormat("DateTime3 == ", DateTime.Now);
                log.DebugFormat("year == ", year);
                log.DebugFormat("month == ", month);
                log.DebugFormat("day == ", day);

                // sleep for 10 seconds.
                Thread.Sleep(1000 * 60 * 60 * 24);
            }
        }

        /// <summary>
        /// 이미지 조회
        /// </summary>
        private void DeleteEmptyImage()
        {
            DolPicAdmin dao = new DolPicAdmin();
            var list = dao.GetDolPicAllImageList();
            // 짤린 이미지 검사
            CheckServer(list);
        }

        /// <summary>
        /// 이미지가 짤렸는지 검색하고 짤린 이미지라면 삭제
        /// </summary>
        /// <param name="a_list">이미지 리스트</param>
        /// <returns></returns>
        private string CheckServer(IList<DolPicVo> a_list)
        {
            string sResult = null;

            HttpWebRequest HttpWReq = null;
            HttpWebResponse HttpWRes = null;
            Stream ResStream = null;
            StreamReader SRResult = null;
            var img = "";
            var seq = 0;

            DolPicVo entity = new DolPicVo();
            AdminDao dao = new AdminDao();

            foreach (var item in a_list)
            {
                img = item.ImageSrc;
                seq = item.Seq;


                log.DebugFormat("img == {0}", img);
                log.DebugFormat("seq == {0}", seq);

                try
                {
                    //WebRequest 객체를 세팅합니다.
                    HttpWReq = (HttpWebRequest)WebRequest.Create(img);
                    //호출 결과를 가져옵니다.
                    HttpWRes = (HttpWebResponse)HttpWReq.GetResponse();

                    //결과 스트림을 생성합니다.
                    ResStream = HttpWRes.GetResponseStream();
                    //스트림리더로 읽습니다.
                    SRResult = new StreamReader(ResStream);
                    //스트림에 있는 것을 문자열에 할당합니다.
                    sResult = SRResult.ReadToEnd().Trim();

                    //열린 모든 객체를 닫습니다.
                    HttpWRes.Close();
                    ResStream.Close();
                    SRResult.Close();
                }
                catch (Exception ex)
                {
                    // 짤린 이미지 삭제
                    entity.Seq = seq;
                    dao.DolPicNoImageDelete(entity);

                    log.DebugFormat("no img == {0}", img);
                    log.DebugFormat("no seq == {0}", seq);
                }
            }

            return sResult;
        }
    }
}