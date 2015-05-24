namespace CacheBusting.Abstractions
{
    public interface IFingerPrintGenerator
    {
        string CreateFingerPrint(string filepath);
    }
}