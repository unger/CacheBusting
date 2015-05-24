namespace CacheBusting.Tests
{
    using CacheBusting.Abstractions;
    using CacheBusting.FingerPrinting;

    using FakeItEasy;

    using NUnit.Framework;

    [TestFixture]
    public class FingerPrinterTests
    {
        private IFingerPrintGenerator fingerPrintGenerator;

        [TestFixtureSetUp]
        public void SetUpFixture()
        {
            this.fingerPrintGenerator = A.Fake<IFingerPrintGenerator>();
            A.CallTo(() => this.fingerPrintGenerator.CreateFingerPrint(A<string>.Ignored)).Returns("1337");
        }

        [TestCase("main.css", true, Result = "main.css?v=1337")]
        [TestCase("main.css?", true, Result = "main.css?&v=1337")]
        [TestCase("main.css?a=b", true, Result = "main.css?a=b&v=1337")]
        [TestCase("main.css", false, Result = "main.1337.css")]
        [TestCase("main.min.css", false, Result = "main.min.1337.css")]
        [TestCase("main", true, Result = "main?v=1337")]
        [TestCase("main/", true, Result = "main/?v=1337")]
        [TestCase("/main", true, Result = "/main?v=1337")]
        [TestCase("main", false, Result = "main/1337")]
        [TestCase("main/", false, Result = "main/1337")]
        [TestCase("/main", false, Result = "/main/1337")]
        public string FingerPrint(string url, bool useQueryString)
        {
            var fingerprinter = new FingerPrinter(this.fingerPrintGenerator, useQueryString);

            return fingerprinter.FingerPrint(url);
        }
    }
}
