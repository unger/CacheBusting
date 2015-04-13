namespace CacheBusting.FingerPrinting
{
    using CacheBusting.Abstractions;

    public class FileDateFingerPrinter : FingerPrinter
    {
        private readonly IFileSystem fileSystem;

        public FileDateFingerPrinter(IFileSystem fileSystem)
        {
            this.fileSystem = fileSystem;
        }

        protected override string CreateFingerPrint(string filepath)
        {
            return this.fileSystem.GetLastWriteTime(filepath).ToString("yyMMddhhmmss");
        }
    }
}
