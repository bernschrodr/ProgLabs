using System;
using System.Collections.Generic;
using System.IO;
namespace exam
{
    public class HtmlWorker
    {
        public readonly string htmlTemplatePath = "./index.html";
        public string? CreateHtml(string query)
        {
            if (!query.Contains("path"))
            {
                throw new Exception("Wrong query");
            }

            int start = query.IndexOf("path=") + "path=".Length - 1;
            string path = query.Substring(start+1);
            query = query.Substring(1);
            int driveEnd = query.IndexOf(":/") + ":/".Length;
            string[] splittedQuery = query.Split(':');
            string driveName = query.Substring(start,3);
            List<string> drivesLinks = new List<string>();
            bool isDriveExist = FileWorker.IsDriveExist(driveName);
            string pathWithoutDrive = query.Substring(driveEnd);
            
            if (!isDriveExist)
            {
                 throw new Exception("Drive not Found");
            }
            bool isDirectory = Directory.Exists(path);
            
            if (isDirectory)
            {
                List<string> linksList;
                try
                {
                    linksList = FileWorker.GetFileLinksList(path, query);
                }
                catch (UnauthorizedAccessException e)
                {
                    throw;
                }

                string inputLinks = String.Join('\n', linksList);
                return EditBodyHtml("<nav>", htmlTemplatePath, inputLinks);
            }

            return null;
        }
        public string EditBodyHtml(string openTag, string filePath, string input)
        {
            int position = -1;
            string page;

            StreamReader htmlFileReader = new StreamReader(filePath);
            page = htmlFileReader.ReadToEnd();
            htmlFileReader.Close();

            int openTagPosition = page.IndexOf(openTag);
            int closeTagPosition = page.IndexOf(openTag.Substring(0, 1) + '/' + openTag.Substring(1, openTag.Length - 1));
            if (openTagPosition == -1 || closeTagPosition == -1)
            {
                throw new Exception("tag not found");
            }
            string result = page.Substring(0, openTagPosition + openTag.Length) + input + page.Substring(closeTagPosition, page.Length - closeTagPosition);

            return result;

        }
        public static string CreateLink(string path, string name)
        {
            return $"<a href='{path}'>{name}</a><br>";
        }
    }
}