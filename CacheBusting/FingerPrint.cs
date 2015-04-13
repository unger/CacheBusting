namespace CacheBusting
{
    using System.IO.Abstractions;

    using CacheBusting.Abstractions;
    using CacheBusting.FingerPrinting;

    public static class FingerPrint
    {
        public static string WithFileDate(string url, bool useQueryString = true)
        {
            var generator = new FileDateFingerPrintGenerator(new FileSystem(), new PathMapper());

            var fingerprinter = new FingerPrinter(generator, useQueryString);
            return fingerprinter.FingerPrint(url);
        }

        public static string WithContentHash(string url, bool useQueryString = true)
        {
            var generator = new ContentHashFingerPrintGenerator(new FileSystem(), new PathMapper());

            var fingerprinter = new FingerPrinter(generator, useQueryString);
            return fingerprinter.FingerPrint(url);
        }
    }
}
