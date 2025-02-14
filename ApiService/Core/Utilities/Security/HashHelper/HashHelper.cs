using System.Security.Cryptography;
using System.Text;

namespace TrendMusic.ECommerce.Core.Utilities.Security.HashHelper
{
    public static class HashHelper
    {
        public static string CreateSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString().Trim().ToUpper();
            }
        }

        public static string Encrypt(this string stringToEncrypt)
        {
            const string pstrEncrKey = "a.k.a.r";
            byte[] iv = {
                                18,
                                52,
                                86,
                                120
                           };
            var byKey = System.Text.Encoding.UTF8.GetBytes(pstrEncrKey.Substring(0, 8));
            var des = new DESCryptoServiceProvider();
            byte[] inputByteArray = Encoding.UTF8.GetBytes(stringToEncrypt);
            var ms = new MemoryStream();
            var cs = new CryptoStream(ms, des.CreateEncryptor(byKey, iv), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return Convert.ToBase64String(ms.ToArray());
        }
        public static string Decrypt(this string stringToDecrypt)
        {
            stringToDecrypt = stringToDecrypt.Replace(" ", "+");
            const string pstrDecrKey = "a.k.a.r";
            byte[] iv = {
                            18,
                            52,
                            86,
                            120,
                  };
            byte[] inputByteArray = new byte[stringToDecrypt.Length];
            var byKey = System.Text.Encoding.UTF8.GetBytes(pstrDecrKey.Substring(0, 8));
            var des = new DESCryptoServiceProvider();
            inputByteArray = Convert.FromBase64String(stringToDecrypt);
            var ms = new MemoryStream();
            var cs = new CryptoStream(ms, des.CreateDecryptor(byKey, iv), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            var encoding = Encoding.UTF8;
            return encoding.GetString(ms.ToArray());
        }
    }
}
