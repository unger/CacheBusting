namespace CacheBusting.Tests
{
    using CacheBusting.Tests.Fakes;

    using NUnit.Framework;

    [TestFixture]
    public class FingerPrinterTests
    {
        [TestCase("main.css", "1337", true, Result = "main.css?v=1337")]
        [TestCase("main.css?", "1337", true, Result = "main.css?&v=1337")]
        [TestCase("main.css?a=b", "1337", true, Result = "main.css?a=b&v=1337")]
        [TestCase("main.css", "1337", false, Result = "main.1337.css")]
        [TestCase("main.min.css", "1337", false, Result = "main.min.1337.css")]
        public string FingerPrint(string url, string fingerprint, bool useQueryString)
        {
            var fingerprinter = new FakeFingerPrinter(fingerprint);

            return fingerprinter.FingerPrint(url, useQueryString);
        }
    }
}
