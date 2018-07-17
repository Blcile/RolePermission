using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace RolePermission.Common
{
    public static class Encrypt
    {
        private const string ENCRYPT_KEY = "RolePermission";

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="strText"></param>
        /// <returns></returns>
        public static string DecodeText(string strText)
        {
            return Decode(strText, ENCRYPT_KEY);
        }
        /// <summary>
        ///  加密
        /// </summary>
        /// <param name="strText"></param>
        /// <param name="strKey"></param>
        /// <returns></returns>
        public static string DecodeText(string strText, string strKey)
        {
            return Decode(strText, strKey);
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="strText"></param>
        /// <returns></returns>
        public static string UnDecodeText(string strText)
        {
            return UnDecode(strText, ENCRYPT_KEY);
        }
        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="strText">要解密的字串</param>
        /// <param name="strKey">解密密匙</param>
        /// <returns>解密后的字符串</returns>
        public static string UnDecodeText(string strText, string strKey)
        {
            return UnDecode(strText, strKey);
        }

        /// <summary>
        /// 加密函数
        /// </summary>
        /// <param name="strText"></param>
        /// <param name="strEncrKey"></param>
        /// <returns></returns>
        private static string Decode(string strText, string strEncrKey)
        {
            byte[] byKey = { };
            byte[] IV = new byte[] { 0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xF0 };

            byKey = System.Text.Encoding.UTF8.GetBytes(strEncrKey.Substring(0, 8));
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray = Encoding.UTF8.GetBytes(strText);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(byKey, IV), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return Convert.ToBase64String(ms.ToArray());
        }

        /// <summary>
        /// 解密函数
        /// </summary>
        /// <param name="strText"></param>
        /// <param name="sDecrKey"></param>
        /// <returns></returns>
        private static string UnDecode(string strText, string sDecrKey)
        {
            byte[] byKey = { };
            byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xF0 };
            byte[] inputByteArray = new byte[strText.Length];

            byKey = System.Text.Encoding.UTF8.GetBytes(sDecrKey.Substring(0, 8));
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            inputByteArray = Convert.FromBase64String(strText);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            System.Text.Encoding encoding = System.Text.Encoding.UTF8;
            return encoding.GetString(ms.ToArray());
        }
    }
}
