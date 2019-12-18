using System.Text.RegularExpressions;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System;
using System.Text.Unicode;

namespace exam
{
    public class Client
    {
        public Client(TcpClient client)
        {
            string indexHtmlPath = "./index.html";

            string request = "";

            byte[] buffer = new byte[1024];

            int count;

            while ((count = client.GetStream().Read(buffer, 0, buffer.Length)) > 0)
            {
                request += Encoding.ASCII.GetString(buffer, 0, count);

                if (request.IndexOf("\r\n\r\n", StringComparison.Ordinal) >= 0 || request.Length > 4096)
                {
                    break;
                }
            }

            Match reqMatch = Regex.Match(request, $@"^\w+\s+([^\s\?]+)[^\s]*\s+HTTP/.*|");

            if (reqMatch == Match.Empty)
            {
                SendError(client, 400);
                return;
            }

            string requestUri = reqMatch.Groups[1].Value;

            requestUri = Uri.UnescapeDataString(requestUri);

            if (requestUri.IndexOf("..", StringComparison.Ordinal) >= 0)
            {
                SendError(client, 400);
                return;
            }
            HtmlWorker htmlWorker = new HtmlWorker();
            string path = "";
            ResponseType responseType = htmlWorker.GetResponseType(requestUri);
            
            path = responseType == ResponseType.Drives
                ? "/"
                : responseType == ResponseType.Directory || responseType == ResponseType.File || responseType == ResponseType.DriveRoot
                    ? requestUri.Substring(requestUri.IndexOf("=", StringComparison.Ordinal) + 1)
                    : "";

            string FilePath;

            DriveInfo[] allDrives = FileWorker._allDrives;
            string htmlPage = "";
            
            switch (responseType)
            {
                case ResponseType.Drives:
                    List<string> drivesLinks = new List<string>();
                    foreach (var drive in allDrives)
                    {
                        drivesLinks.Add(HtmlWorker.CreateLink($"./path={drive.Name}", drive.Name));
                    }

                    string allLinks = "";
                    foreach (var link in drivesLinks)
                    {
                        allLinks += $"{link}\n";
                    }

                    htmlPage = htmlWorker.EditBodyHtml("<nav>", indexHtmlPath, allLinks);
                    break;
                case ResponseType.DriveRoot:
                    string diskName = path;
                    DirectoryInfo driveRoot = FileWorker.GetDriveRoot(diskName);
                    var fileLinksList = FileWorker.GetFileLinksList(driveRoot, requestUri);
                    allLinks = "";
                    foreach (var link in fileLinksList)
                    {
                        allLinks += $"{link}\n";
                    }

                    htmlPage = htmlWorker.EditBodyHtml("<nav>", indexHtmlPath, allLinks);
                    break;
                case ResponseType.Directory:
                    string? htmlBuff;
                    try
                    {
                        htmlBuff = htmlWorker.CreateHtml(requestUri);
                        if (htmlBuff != null)
                        {
                            htmlPage = htmlWorker.EditBodyHtml("<nav>", indexHtmlPath, htmlBuff);
                        }
                        else
                        {
                            htmlPage = htmlWorker.EditBodyHtml("<nav>", indexHtmlPath, "<h1>Directory Not Exist</h1>");
                        }
                    }
                    catch (UnauthorizedAccessException)
                    {
                        htmlPage = htmlWorker.EditBodyHtml("<nav>", indexHtmlPath,
                            "<h1>No permissions to view this folder</h1>");
                    }

                    break;
                case ResponseType.File:
                    if (File.Exists(path))
                    {
                        htmlPage = "";
                    }
                    else
                    {
                        SendError(client, 404);
                        return;
                    }

                    break;
            }

            string extension = responseType != ResponseType.File
                ? ".html"
                : requestUri.Substring(requestUri.LastIndexOf('.'));

            string contentType = "";

            switch (extension)
            {
                case ".log":
                case ".LOG":
                case  ".txt":
                case ".htm":
                case ".html":
                    contentType = "text/html";
                    break;
                case ".css":
                    contentType = "text/stylesheet";
                    break;
                case ".js":
                    contentType = "text/javascript";
                    break;
                case ".jpg":
                    contentType = "image/jpeg";
                    break;
                case ".jpeg":
                case ".png":
                case ".gif":
                    contentType = $"image/{extension.Substring(1)}";
                    break;
                default:
                    if (extension.Length > 1)
                    {
                        contentType = $"application/{extension.Substring(1)}";
                    }
                    else
                    {
                        contentType = "application/unknown";
                    }

                    break;
            }

            FileStream fs = null;
            try
            {
                if (responseType == ResponseType.File)
                {
                    FilePath = path;
                    fs = new FileStream(FilePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                }
            }
            catch (Exception)
            {
                SendError(client, 500);
                return;
            }

            Byte[] sendBytes = Encoding.UTF8.GetBytes(htmlPage);
            string contentLength = (fs == null ? sendBytes.Length : fs.Length).ToString();

            string headers = $"HTTP/1.1 200 OK\nContent-Type: {contentType}\nContent-Length: {contentLength}\n\n";
            byte[] headersBuffer = Encoding.ASCII.GetBytes(headers);
            client.GetStream().Write(headersBuffer, 0, headersBuffer.Length);

            if (responseType != ResponseType.File)
            {
                try
                {
                    client.GetStream().Write(sendBytes, 0, sendBytes.Length);
                }
                catch
                {
                }
            }
            else
            {
                if (contentType == "text/html" && responseType == ResponseType.File)
                {
                    try
                    {
                        StreamReader sr = new StreamReader(path);
                        string textBuffer = sr.ReadToEnd();
                        textBuffer = textBuffer.Replace("\n", "<br>")
                            .Replace("\t", "<span style=\"padding: 0px 10px;\">&nbsp;</span>");
                        byte[] page = Encoding.UTF8.GetBytes(textBuffer);
                        client.GetStream().Write(page, 0, page.Length);

                    }
                    catch (Exception)
                    {
                        SendError(client, 500);
                        return;
                    }
                    
                }
                else
                {
                    while (fs != null && fs.Position < fs.Length)
                    {
                        count = fs.Read(buffer, 0, buffer.Length);

                        client.GetStream().Write(buffer, 0, count);
                    }
                }
                

                if (fs != null) fs.Close();
            }

            client.Close();
        }

        private void SendError(TcpClient client, int code)
        {
            string codeStr = $"{code} {((HttpStatusCode) code)}";

            string html = $"<html><body><h1>{codeStr}</h1></body></html>";

            string str = $"HTTP/1.1 {codeStr}\nContent-type: text/html\nContent-Length:{html.Length}\n\n{html}";

            byte[] buffer = Encoding.ASCII.GetBytes(str);

            client.GetStream().Write(buffer, 0, buffer.Length);

            client.Close();
        }
    }
}