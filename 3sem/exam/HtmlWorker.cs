using System.IO;
namespace HTTPServer
{
    static public class HtmlWorker
    {
        async static public void EditBodyHtml(string openTag, string filePath, string input)
        {
            int position = -1;
            string page;

            StreamReader htmlFileReader = new StreamReader(filePath);
            page = await htmlFileReader.ReadToEndAsync();
            htmlFileReader.Close();

            int openTagPosition = page.IndexOf(openTag);
            int closeTagPosition = page.IndexOf(openTag.Substring(0, 1) + '/' + openTag.Substring(1, openTag.Length - 1));
            if (openTagPosition == -1 || closeTagPosition == -1)
            {
                return;
            }
            string result = page.Substring(0, openTagPosition + openTag.Length) + input + page.Substring(closeTagPosition, page.Length - closeTagPosition);

            StreamWriter htmlFileWritter = new StreamWriter(filePath);
            await htmlFileWritter.WriteAsync(result);
            htmlFileWritter.Close();

        }
        static public string CreateLink(string path, string name)
        {
            return $"<a href='{path}'>{name}</a>";
        }
    }
}