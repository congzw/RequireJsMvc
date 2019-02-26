using System;
using System.IO;
using System.Text;
using System.Web.Hosting;

namespace CommonFx.Web
{
    public interface IFileServer
    {
        string MapPath(string relativePath);
        bool Exists(string filePath);
        string ReadAllText(string filePath, Encoding encoding = null);
        void WriteAllText(string filePath, string contents, Encoding encoding = null);
    }

    public class FileServer : IFileServer
    {
        #region for di extensions

        private static Lazy<IFileServer> _lazy = new Lazy<IFileServer>(() => new FileServer());
        private static Func<IFileServer> _resolve = () => _lazy.Value;
        public static Func<IFileServer> Resolve
        {
            get { return _resolve; }
            set { _resolve = value; }
        }

        #endregion

        public string MapPath(string relativePath)
        {
            return HostingEnvironment.MapPath(relativePath);
        }

        public bool Exists(string path)
        {
            return File.Exists(path);
        }

        public string ReadAllText(string filePath, Encoding encoding = null)
        {
            return encoding == null ? File.ReadAllText(filePath) : File.ReadAllText(filePath, encoding);
        }

        public void WriteAllText(string filePath, string contents, Encoding encoding = null)
        {
            if (encoding == null)
            {
                File.WriteAllText(filePath, contents);
            }
            else
            {
                File.WriteAllText(filePath, contents, encoding);
            }
        }
    }
}
