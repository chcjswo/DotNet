using System;
using System.IO;
using System.Security.Cryptography;
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
    }
    public class DolPicEncryption
    {
        private const string CODE_KEY = "dolpic";

        //암호화에 사용되는 Key 값을 선언합니다.
        static byte[] pbyteKey = ASCIIEncoding.ASCII.GetBytes(CODE_KEY);
        //위의 pbyteKey 변수는 아래의 Encrypt 와 Decrypt 함수에서 정의되서 사용해도 됩니다.
        //단... 암호화하는데 쓰이는 Key 값은 동일해야 합니다.
        //아래의 Encrypt 와 Decrypt 함수를 선언합니다.

        /// <summary>
        /// Base64 엔코딩
        /// </summary>
        /// <param name="a_sOri"></param>
        /// <returns></returns>
        public static string Base64Encode(string a_sOri)
        {
            byte[] arrByte = Encoding.Default.GetBytes(a_sOri);

            return Convert.ToBase64String(arrByte);
        }

        /// <summary>
        /// Base64 디코딩
        /// </summary>
        /// <param name="a_sOri"></param>
        /// <returns></returns>
        public static string Base64Decode(string a_sOri)
        {
            if (string.IsNullOrEmpty(a_sOri)) return a_sOri;

            return Encoding.Default.GetString(Convert.FromBase64String(a_sOri));
        }

        // 암호화 하고자 하는 Key 값(String) 을 받아서 DES 알고리즘으로 암호화한 문자열을 Return 함
        public static string Encrypt(String strKey)
        {
            DESCryptoServiceProvider desCSP = new DESCryptoServiceProvider();
            desCSP.Mode = CipherMode.ECB;
            desCSP.Padding = PaddingMode.PKCS7;
            desCSP.Key = pbyteKey;
            desCSP.IV = pbyteKey;
            MemoryStream ms = new MemoryStream();
            CryptoStream cryptStream = new CryptoStream(ms, desCSP.CreateEncryptor(), CryptoStreamMode.Write);
            byte[] data = Encoding.UTF8.GetBytes(strKey.ToCharArray());
            cryptStream.Write(data, 0, data.Length);
            cryptStream.FlushFinalBlock();
            String strReturn = Convert.ToBase64String(ms.ToArray());
            cryptStream = null;
            ms = null;
            desCSP = null;

            return strReturn;
        }

        // DES 알고리즘으로 암호화된 문자열을 받아서 복호화 한 후 암호화 이전의 원래 문자열을 Return 함
        public static string Decrypt(String strKey)
        {
            DESCryptoServiceProvider desCSP = new DESCryptoServiceProvider();
            desCSP.Mode = CipherMode.ECB;
            desCSP.Padding = PaddingMode.PKCS7;
            desCSP.Key = pbyteKey;
            desCSP.IV = pbyteKey;
            MemoryStream ms = new MemoryStream();
            CryptoStream cryptStream = new CryptoStream(ms, desCSP.CreateDecryptor(), CryptoStreamMode.Write);
            strKey = strKey.Replace(" ", "+");
            byte[] data = Convert.FromBase64String(strKey);
            cryptStream.Write(data, 0, data.Length);
            cryptStream.FlushFinalBlock();
            String strReturn = Encoding.UTF8.GetString(ms.GetBuffer());
            cryptStream = null;
            ms = null;
            desCSP = null;

            return strReturn;
        }
    }
}
