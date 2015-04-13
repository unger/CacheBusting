namespace CacheBusting.FingerPrinting
{
    using CacheBusting.Abstractions;

    public class ContentHashFingerPrinter : FingerPrinter
    {
        private readonly IFileSystem fileSystem;

        public ContentHashFingerPrinter(IFileSystem fileSystem)
        {
            this.fileSystem = fileSystem;
        }

        protected override string CreateFingerPrint(string filepath)
        {
            return this.fileSystem.GetContentHash(filepath);
        }
    }
}
