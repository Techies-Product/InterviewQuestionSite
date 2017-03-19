using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace InterviewSite.Models
{
    public class CommonFunctions
    {
        public static string GetUserId()
        {
            string[] splitedGuid = Guid.NewGuid().ToString().Split('-');
            return splitedGuid[splitedGuid.Length - 1] + DateTime.Now.ToString("ddMMyyyyhhmmsstt");
        }
        public static byte[] Encryption(string PlainText, string Key)
        {
            TripleDES des = CreateDES(Key);
            ICryptoTransform cryptoTransform = des.CreateEncryptor();
            byte[] input = Encoding.Unicode.GetBytes(PlainText);
            return cryptoTransform.TransformFinalBlock(input, 0, input.Length);
        }
        public static string Decryption(string CypherText, string Key)
        {
            byte[] b = Convert.FromBase64String(CypherText);
            TripleDES des = CreateDES(Key);
            ICryptoTransform cryptoTransform = des.CreateDecryptor();
            byte[] output = cryptoTransform.TransformFinalBlock(b, 0, b.Length);
            return Encoding.Unicode.GetString(output);
        }
        private static TripleDES CreateDES(string Key)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            TripleDES des = new TripleDESCryptoServiceProvider();
            des.Key = md5.ComputeHash(Encoding.Unicode.GetBytes(Key));
            des.IV = new byte[des.BlockSize / 8];
            return des;
        }
        public static string GetAdminMenu()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<li><select id='AdminMenu'>");
            sb.Append("<option>--Select Admin Item--</option>");
            sb.Append("<option data-href='/tags'>Manage Tags</option>");
            sb.Append("</select></li>");
            return sb.ToString();
        }
    }
}