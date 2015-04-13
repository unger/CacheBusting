namespace CacheBusting.FingerPrinting
{
    public class FingerPrinter
    {
        private readonly IFingerPrintGenerator generator;

        private readonly bool useQueryString;

        public FingerPrinter(IFingerPrintGenerator generator, bool useQueryString)
        {
            this.generator = generator;
            this.useQueryString = useQueryString;
        }

        public virtual string FingerPrint(string url)
        {
            var fingerprint = this.generator.CreateFingerPrint(url);

            if (this.useQueryString)
            {
                url = string.Concat(url, url.Contains("?") ? "&" : "?", "v=", fingerprint);
            }
            else
            {
                int index = url.LastIndexOf('.');
                url = index != -1 
                    ? url.Insert(index, "." + fingerprint) 
                    : url.EndsWith("/") 
                        ? string.Concat(url, fingerprint)
                        : string.Concat(url, "/", fingerprint);
            }

            return url;
        }
    }
}