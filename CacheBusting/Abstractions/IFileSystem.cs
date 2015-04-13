namespace CacheBusting.Abstractions
{
    using System;

    public interface IFileSystem
    {
        DateTime GetLastWriteTime(string rootRelativePath);

        string GetContentHash(string url);
    }
}