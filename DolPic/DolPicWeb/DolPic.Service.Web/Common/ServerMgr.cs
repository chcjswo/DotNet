using DolPic.Common;
using log4net;
using System.Net.Http;
using System.Net.Http.Formatting;
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

        /// <summary>
        /// 서버 시작시 실행
        /// </summary>
        public void Init()
        {
            // create a delegate of MethodInvoker poiting to
            // our Foo function.
            MethodInvoker simpleDelegate = new MethodInvoker(DailyCheck);

            // Calling DailyCheck Async
            simpleDelegate.BeginInvoke(null, null);
        }

        /// <summary>
        /// 서버 다운시 실행
        /// </summary>
        public void Fin()
        {
        }

        public delegate void MethodInvoker();

        private void DailyCheck()
        {
            while (true)
            {
                // 짤린 이미지 삭제
                DolPicNoImageDelete();

                // sleep for 24 hours.
                Thread.Sleep(1000 * 60 * 60 * 24);
            }
        }

        /// <summary>
        /// 짤린 이미지 삭제 호출
        /// </summary>
        private void DolPicNoImageDelete()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.ExpectContinue = false;
                var result = client.PostAsync(string.Format("{0}/Pics/DolPicNoImageDelete", Domains.WebDomain),
                new
                {
                }, new JsonMediaTypeFormatter()).Result;
            }
        }
    }
}