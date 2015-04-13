namespace CacheBusting.FingerPrinting
{
    using System.IO.Abstractions;
    using System.Security.Cryptography;
    using System.Text;

    using CacheBusting.Abstractions;

    public class ContentHashFingerPrintGenerator : IFingerPrintGenerator
    {
        private readonly IFileSystem fileSystem;

        private readonly IPathMapper pathMapper;

        public ContentHashFingerPrintGenerator(IFileSystem fileSystem, IPathMapper pathMapper)
        {
            this.fileSystem = fileSystem;
            this.pathMapper = pathMapper;
        }

        public string CreateFingerPrint(string filepath)
        {
            var absPath = this.pathMapper.MapPath(filepath);

            if (this.fileSystem.File.Exists(absPath))
            {
                byte[] fileData = this.fileSystem.File.ReadAllBytes(absPath);
                byte[] hash = MD5.Create().ComputeHash(fileData);

                return this.ToHex(hash, true);
            }

            return null;
        }

        private string ToHex(byte[] bytes, bool upperCase)
        {
            var result = new StringBuilder(bytes.Length * 2);

            for (int i = 0; i < bytes.Length; i++)
            {
                result.Append(bytes[i].ToString(upperCase ? "X2" : "x2"));
            }

            return result.ToString();
        }
    }
}
