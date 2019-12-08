using System.Text.RegularExpressions;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System;


namespace exam
{
    // Класс-обработчик клиента

    public class Client
    {
        

        // Конструктор класса. Ему нужно передавать принятого клиента от TcpListener
        public Client(TcpClient Client)
        {
            string indexHtmlPath = "./index.html";
            // Объявим строку, в которой будет хранится запрос клиента
            string Request = "";
            // Буфер для хранения принятых от клиента данных
            byte[] Buffer = new byte[1024];
            // Переменная для хранения количества байт, принятых от клиента
            int Count;
            // Читаем из потока клиента до тех пор, пока от него поступают данные
            while ((Count = Client.GetStream().Read(Buffer, 0, Buffer.Length)) > 0)
            {
                // Преобразуем эти данные в строку и добавим ее к переменной Request
                Request += Encoding.ASCII.GetString(Buffer, 0, Count);
                // Запрос должен обрываться последовательностью \r\n\r\n
                // Либо обрываем прием данных сами, если длина строки Request превышает 4 килобайта
                // Нам не нужно получать данные из POST-запроса (и т. п.), а обычный запрос
                // по идее не должен быть больше 4 килобайт
                if (Request.IndexOf("\r\n\r\n") >= 0 || Request.Length > 4096)
                {
                    break;
                }
            }

            // Парсим строку запроса с использованием регулярных выражений
            // При этом отсекаем все переменные GET-запроса
            Match ReqMatch = Regex.Match(Request, $@"^\w+\s+([^\s\?]+)[^\s]*\s+HTTP/.*|");

            // Если запрос не удался
            if (ReqMatch == Match.Empty)
            {
                // Передаем клиенту ошибку 400 - неверный запрос
                SendError(Client, 400);
                return;
            }
            
            // Получаем строку запроса
            string RequestUri = ReqMatch.Groups[1].Value;

            // Приводим ее к изначальному виду, преобразуя экранированные символы
            // Например, "%20" -> " "
            RequestUri = Uri.UnescapeDataString(RequestUri);



            // Если в строке содержится двоеточие, передадим ошибку 400
            // Это нужно для защиты от URL типа http://example.com/../../file.txt
            if (RequestUri.IndexOf("..") >= 0)
            {
                SendError(Client, 400);
                return;
            }

            string path = "";
            ResponseType responseType = ResponseType.Drives;

            if (RequestUri.Equals("/"))
            {
                path = "/";
                responseType = ResponseType.Drives;
            }
            if (RequestUri.Contains("path="))
            {
                path = RequestUri.Substring(RequestUri.IndexOf("=") + 1);
                responseType = ResponseType.Directory;
                if (RequestUri.Contains("."))
                {
                    responseType = ResponseType.File;
                }
            }
            if (path != String.Empty && responseType != ResponseType.Drives && path.Length < 4)
            {
                responseType = ResponseType.DriveRoot;
            }
            
            string FilePath;

            DriveInfo[] allDrives = FileWorker._allDrives;
            string htmlPage = "";
            HtmlWorker htmlWorker = new HtmlWorker();
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
                case  ResponseType.DriveRoot:
                    string diskName = path;
                    DirectoryInfo driveRoot = FileWorker.GetDriveRoot(diskName);
                    var fileLinksList = FileWorker.GetFileLinksList( driveRoot, RequestUri);
                    allLinks = "";
                    foreach (var link in fileLinksList)
                    {
                        allLinks += $"{link}\n";
                    }
                    htmlPage = htmlWorker.EditBodyHtml("<nav>", indexHtmlPath, allLinks);
                    break;
                case  ResponseType.Directory:
                    string? htmlBuff;
                    try
                    {
                        htmlBuff = htmlWorker.CreateHtml(RequestUri);
                        if (htmlBuff != null)
                        {
                            htmlPage = htmlWorker.EditBodyHtml("<nav>", indexHtmlPath, htmlBuff);
                        }
                        else
                        {
                            htmlPage = htmlWorker.EditBodyHtml("<nav>", indexHtmlPath, "<h1>Directory Not Exist</h1>");
                        }
                    }
                    catch (UnauthorizedAccessException e)
                    {
                        htmlPage = htmlWorker.EditBodyHtml("<nav>", indexHtmlPath, "<h1>No permissions to view this folder</h1>");
                    }

                    break;
                case ResponseType.File:
                    if (File.Exists(path))
                    {
                        htmlPage = "";
                    }
                    else
                    {
                        SendError(Client, 404);
                        return;
                    }
                    break;
            }
            
            // Получаем расширение файла из строки запроса
            string Extension = responseType != ResponseType.File ? ".html" : RequestUri.Substring(RequestUri.LastIndexOf('.'));

            // Тип содержимого
            string ContentType = "";

            // Пытаемся определить тип содержимого по расширению файла
            switch (Extension)
            {
                case ".htm":
                case ".html":
                    ContentType = "text/html";
                    break;
                case ".css":
                    ContentType = "text/stylesheet";
                    break;
                case ".js":
                    ContentType = "text/javascript";
                    break;
                case ".jpg":
                    ContentType = "image/jpeg";
                    break;
                case ".jpeg":
                case ".png":
                case ".gif":
                    ContentType = $"image/{Extension.Substring(1)}";
                    break;
                default:
                    if (Extension.Length > 1)
                    {
                        ContentType = $"application/{Extension.Substring(1)}";
                    }
                    else
                    {
                        ContentType = "application/unknown";
                    }
                    break;
            }
            
            // Открываем файл, страхуясь на случай ошибки
            FileStream FS = null;
            try
            {
                if (responseType == ResponseType.File)
                {
                    FilePath = path;
                    FS = new FileStream(FilePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                }

            }
            catch (Exception)
            {
                // Если случилась ошибка, посылаем клиенту ошибку 500
                SendError(Client, 500);
                return;
            }
            Byte[] sendBytes = Encoding.UTF8.GetBytes(htmlPage);
            string contentLength = (FS == null ? sendBytes.Length : FS.Length).ToString();
            // Посылаем заголовки
            string Headers = $"HTTP/1.1 200 OK\nContent-Type: {ContentType}\nContent-Length: {contentLength}\n\n";
            byte[] HeadersBuffer = Encoding.ASCII.GetBytes(Headers);
            Client.GetStream().Write(HeadersBuffer, 0, HeadersBuffer.Length);

            if (responseType != ResponseType.File)
            {
                try
                {
                    Client.GetStream().Write(sendBytes, 0, sendBytes.Length);
                }
                catch
                {
                    
                }
            }
            else
            {
                // Пока не достигнут конец файла
                while (FS.Position < FS.Length)
                {
                    // Читаем данные из файла
                    Count = FS.Read(Buffer, 0, Buffer.Length);
                    // И передаем их клиенту
                    Client.GetStream().Write(Buffer, 0, Count);
                }
                // Закроем файл и соединение
                FS.Close();
            }
            
            Client.Close();
        }

        // Отправка страницы с ошибкой
        private void SendError(TcpClient Client, int Code)
        {
            // Получаем строку вида "200 OK"
            // HttpStatusCode хранит в себе все статус-коды HTTP/1.1
            string CodeStr = $"{Code} {((HttpStatusCode) Code)}";
            // Код простой HTML-странички
            string Html = $"<html><body><h1>{CodeStr}</h1></body></html>";
            // Необходимые заголовки: ответ сервера, тип и длина содержимого. После двух пустых строк - само содержимое
            string Str = $"HTTP/1.1 {CodeStr}\nContent-type: text/html\nContent-Length:{Html.Length}\n\n{Html}";
            // Приведем строку к виду массива байт
            byte[] Buffer = Encoding.ASCII.GetBytes(Str);
            // Отправим его клиенту
            Client.GetStream().Write(Buffer, 0, Buffer.Length);
            // Закроем соединение
            Client.Close();
        }


    }
}