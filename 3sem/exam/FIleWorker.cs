using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace exam
{
    public static class FileWorker
    {
        public static DriveInfo[] _allDrives = DriveInfo.GetDrives();
        public static List<string> GetFileLinksList(string directory, string currentPath)
        {
            string[] files;
            string[] directories;
            try
            {
                files = Directory.GetFiles(directory);
                directories = Directory.GetDirectories(directory);
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine("no permissions to view the folder");
                throw;
            }

            List<string> filesLinks = new List<string>();
            foreach (var dir in directories)
            {
                string name = dir.Substring(dir.LastIndexOf('\\') + 1);
                filesLinks.Add(HtmlWorker.CreateLink("/" + currentPath + "/" + name, name));
            }
            foreach (var file in files)
            {
                string name = file.Substring(file.LastIndexOf('\\') + 1);
                filesLinks.Add(HtmlWorker.CreateLink("/" + currentPath + "/" + name, name));
            }
           
            if (filesLinks.Count == 0)
            {
                filesLinks.Add("<h1>No Files In this Folder</h1>");
            }
            return filesLinks;
        }
        
        public static List<string> GetFileLinksList(DirectoryInfo directory, string currentPath)
        {
            var files = directory.GetFiles();
            var filtered = files.Where(f => !f.Attributes.HasFlag(FileAttributes.Hidden));
            var directories = directory.GetDirectories();
            var filteredDir = directories.Where(f => !f.Attributes.HasFlag(FileAttributes.Hidden));
            List<string> filesLinks = new List<string>();
            foreach (var dir in filteredDir)
            {
                filesLinks.Add(HtmlWorker.CreateLink(currentPath + dir.Name, dir.Name));
            }
            foreach (var file in filtered)
            {
                filesLinks.Add(HtmlWorker.CreateLink(currentPath + file.Name, file.Name));
            }
            if (filesLinks.Count == 0)
            {
                filesLinks.Add("<h1>No Files In this Folder</h1>");
            }
            return filesLinks;
        }


        public static bool IsDriveExist(string driveName)
        {
            driveName = driveName.Replace('/', '\\');
            foreach (var drive in _allDrives)
            {
                if (driveName == drive.Name)
                {
                    return true;
                }
            }
            return false;
        }

        public static DirectoryInfo GetDriveRoot(string driveName)
        {
           driveName = driveName.Replace('/', '\\');
            foreach (var drive in _allDrives)
            {
                if (driveName == drive.Name)
                {
                    return drive.RootDirectory;
                }
            }
            return null;
        }
    }
}