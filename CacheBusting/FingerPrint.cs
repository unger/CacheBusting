namespace CacheBusting
{
    using CacheBusting.Abstractions;
    using CacheBusting.FingerPrinting;

    public static class FingerPrint
    {
        public static string WithFileDate(string url, bool useQueryString = true)
        {
            var fingerprinter = new FileDateFingerPrinter(new FileSystem());
            return fingerprinter.FingerPrint(url, useQueryString);
        }

        public static string WithContentHash(string url, bool useQueryString = true)
        {
            var fingerprinter = new ContentHashFingerPrinter(new FileSystem());
            return fingerprinter.FingerPrint(url, useQueryString);
        }
    }
}
