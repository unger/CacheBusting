namespace CacheBusting.Abstractions
{
    using System.Web.Hosting;

    public class PathMapper : IPathMapper
    {
        public string MapPath(string path)
        {
            return HostingEnvironment.MapPath(path);
        }
    }
}
