namespace CacheBusting.Tests.Fakes
{
    using CacheBusting.FingerPrinting;

    public class FakeFingerPrinter : FingerPrinter
    {
        private readonly string fingerprint;

        public FakeFingerPrinter(string fingerprint)
        {
            this.fingerprint = fingerprint;
        }

        protected override string CreateFingerPrint(string filepath)
        {
            return this.fingerprint;
        }
    }
}
