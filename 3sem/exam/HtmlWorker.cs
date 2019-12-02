using System.IO;
namespace HTTPServer
{
    static public class HtmlWorker
    {
        static public void EditBodyHtml(string openTag, string filePath, string input)
        {
            int position = -1;
            string page;

            using (StreamReader htmlFile = new StreamReader(filePath))
            {
                page = htmlFile.ReadToEnd();
                htmlFile.Close();
            }

            int openTagPosition = page.IndexOf(openTag);
            int closeTagPosition = page.IndexOf(openTag.Substring(0, 1) + '/' + openTag.Substring(1, openTag.Length - 1));
            if (openTagPosition == -1 || closeTagPosition == -1)
            {
                return;
            }
            string result = page.Substring(0, openTagPosition) + input + page.Substring(closeTagPosition, page.Length - closeTagPosition);

            using (StreamWriter htmlFile = new StreamWriter(filePath))
            {
                htmlFile.Write(result);
                htmlFile.Close();
            }
        }
        static public string CreateLink(string path, string name)
        {
            return $"<a href='{path}'>{name}</a>";
        }
    }
}