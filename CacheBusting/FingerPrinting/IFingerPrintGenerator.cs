namespace CacheBusting.FingerPrinting
{
    public interface IFingerPrintGenerator
    {
        string CreateFingerPrint(string filepath);
    }
}