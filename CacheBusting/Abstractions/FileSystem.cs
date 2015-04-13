namespace CacheBusting.Abstractions
{
    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;
    using System.Web;
    using System.Web.Hosting;

    public class FileSystem : IFileSystem
    {
        public DateTime GetLastWriteTime(string rootRelativePath)
        {
            var date = DateTime.MinValue;
            var absPath = this.MapPath(rootRelativePath);
            if (absPath != null)
            {
                date = File.GetLastWriteTime(absPath);
            }

            return date;
        }

        public string GetContentHash(string url)
        {
            var absPath = this.MapPath(url);
            if (absPath != null)
            {
                byte[] fileData = File.ReadAllBytes(absPath);
                byte[] hash = MD5.Create().ComputeHash(fileData);

                return Encoding.UTF8.GetString(hash);
            }

            return string.Empty;
        }

        private string MapPath(string rootRelativePath)
        {
            if (rootRelativePath.StartsWith("~"))
            {
                rootRelativePath = rootRelativePath.Substring(1);
            }

            string virtualPath = VirtualPathUtility.ToAbsolute("~" + rootRelativePath);
            string absolute = HostingEnvironment.MapPath(virtualPath);
            if (absolute != null && File.Exists(absolute))
            {
                return absolute;
            }

            return null;
        }
    }
}