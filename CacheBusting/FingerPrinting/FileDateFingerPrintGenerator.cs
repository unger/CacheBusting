namespace CacheBusting.FingerPrinting
{
    using System.IO.Abstractions;

    using CacheBusting.Abstractions;

    public class FileDateFingerPrintGenerator : IFingerPrintGenerator
    {
        private readonly IFileSystem fileSystem;

        private readonly IPathMapper pathMapper;

        public FileDateFingerPrintGenerator(IFileSystem fileSystem, IPathMapper pathMapper)
        {
            this.fileSystem = fileSystem;
            this.pathMapper = pathMapper;
        }

        public string CreateFingerPrint(string filepath)
        {
            var absPath = this.pathMapper.MapPath(filepath);

            if (this.fileSystem.File.Exists(absPath))
            {
                return this.fileSystem.File.GetLastWriteTime(absPath).ToString("yyMMddhhmmss");
            }

            return null;
        }
    }
}
