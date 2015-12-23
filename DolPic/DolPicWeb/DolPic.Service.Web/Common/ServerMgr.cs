
using log4net;
using System;
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
            log.DebugFormat("DateTime1 == ", DateTime.Now);
        }

        public void Init()
        {
            log.DebugFormat("DateTime2 == ", DateTime.Now);
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
                // sleep for 10 seconds.
                Thread.Sleep(1000 * 1);

                log.Debug("aaaaaa");

                int year = DateTime.Now.Year;
                var month = DateTime.Now.Month;
                var day = DateTime.Now.Date;

                //if (Convert.ToDateTime(string.Format("{0}-{1}-{2} 17:45:00")) <= DateTime.Now)
                //{
                //    log.DebugFormat("year == ", year);
                //    log.DebugFormat("month == ", month);
                //    log.DebugFormat("day == ", day);
                //}
                log.DebugFormat("DateTime3 == ", DateTime.Now);
                log.DebugFormat("year == ", year);
                log.DebugFormat("month == ", month);
                log.DebugFormat("day == ", day);
            }

        }
    }
}