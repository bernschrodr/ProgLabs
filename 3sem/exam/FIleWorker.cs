using System.Collections.Generic;
using System.IO;
namespace HTTPServer
{
    public static class FileWorker
    {
        public static List<string> GetFileLinksList(string directory)
        {
            var files = Directory.GetFiles(directory);
            List<string> filesLinks = new List<string>();
            foreach (var file in files)
            {
                filesLinks.Add(HtmlWorker.CreateLink("./" + file, file));
            }
            string links = "";
            foreach (var link in filesLinks)
            {
                links += link + '\n';
            }
            return filesLinks;
        }
    }
}