namespace CacheBusting
{
    using System.IO.Abstractions;
    using System.Web;
    using System.Web.Caching;

    using CacheBusting.Abstractions;
    using CacheBusting.FingerPrinting;

    public static class FingerPrint
    {
        public static string WithFileDate(string url, bool useQueryString = true)
        {
            var pathMapper = new PathMapper();
            var generator = new FileDateFingerPrintGenerator(new FileSystem(), pathMapper);

            return FingerPrintInternal(generator, pathMapper, url, useQueryString);
        }

        public static string WithContentHash(string url, bool useQueryString = true)
        {
            var pathMapper = new PathMapper();
            var generator = new ContentHashFingerPrintGenerator(new FileSystem(), pathMapper);

            return FingerPrintInternal(generator, pathMapper, url, useQueryString);
        }

        private static string FingerPrintInternal(IFingerPrintGenerator fingerPrintGenerator, IPathMapper pathMapper, string virtualPath, bool useQueryString = true)
        {
            var cacheKey = string.Concat(virtualPath, "|", useQueryString, "|", fingerPrintGenerator.GetType().FullName);
            if (HttpRuntime.Cache[cacheKey] == null)
            {
                var absolute = pathMapper.MapPath(virtualPath);
                var fingerprinter = new FingerPrinter(fingerPrintGenerator, useQueryString);
                var fingerprintedUrl = fingerprinter.FingerPrint(virtualPath);

                HttpRuntime.Cache.Insert(cacheKey, fingerprintedUrl, new CacheDependency(absolute));
            }

            return HttpRuntime.Cache[cacheKey] as string;
        }
    }
}
