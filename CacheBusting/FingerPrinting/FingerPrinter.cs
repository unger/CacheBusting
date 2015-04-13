namespace CacheBusting.FingerPrinting
{
    public abstract class FingerPrinter
    {
        public string FingerPrint(string filepath, bool useQueryString = true)
        {
            return this.InjectFingerPrinting(filepath, this.CreateFingerPrint(filepath), useQueryString);
        }

        protected abstract string CreateFingerPrint(string filepath);

        protected virtual string InjectFingerPrinting(string url, string fingerprint, bool useQueryString = true)
        {
            if (useQueryString)
            {
                url = string.Concat(url, url.Contains("?") ? "&" : "?", "v=", fingerprint);
            }
            else
            {
                int index = url.LastIndexOf('.');
                if (index != -1)
                {
                    url = url.Insert(index, "." + fingerprint);
                }
                else
                {
                    url = string.Concat(url, "/", fingerprint);
                }
            }

            return url;
        }        
    }
}