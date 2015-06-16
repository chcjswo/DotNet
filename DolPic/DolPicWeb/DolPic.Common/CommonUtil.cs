using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
