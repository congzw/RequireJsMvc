using System;
using System.Security.Cryptography;
using System.Text;

namespace CommonFx
{
    public interface IHashHelper
    {
        string HashBytes(byte[] bytes);
        string HashString(string str);
    }

    public class HashHelper : IHashHelper
    {
        #region for di extensions

        private static Lazy<IHashHelper> _lazy = new Lazy<IHashHelper>(() => new HashHelper());
        private static Func<IHashHelper> _resolve = () => _lazy.Value;
        public static Func<IHashHelper> Resolve
        {
            get { return _resolve; }
            set { _resolve = value; }
        }

        #endregion


        public string HashBytes(byte[] bytes)
        {
            if (bytes == null)
            {
                return string.Empty;
            }
            using (var md5 = MD5.Create())
            {
                return ConvertHashBytesToString(md5.ComputeHash(bytes));
            }
        }

        public string HashString(string str)
        {
            if (str == null)
            {
                return string.Empty;
            }
            var bytes = Encoding.UTF8.GetBytes(str);
            return HashBytes(bytes);
        }

        //helpers
        private static string ConvertHashBytesToString(byte[] bytes)
        {
            var sBuilder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                sBuilder.Append(bytes[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
    }
}
