using Microsoft.AspNetCore.StaticFiles;
using MVC_ContentType.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.IO;
using System.Web;
using System.Security.Cryptography.Pkcs;
using MimeMapping;

namespace MVC_ContentType.Services
{
    public class MimeMappingService : IMimeMappingService
    {
        private readonly FileExtensionContentTypeProvider _contentTypeProvider;
        private static readonly byte[] JPG = { 255, 216, 255 };
        private static readonly byte[] PNG = { 137, 80, 78, 71, 13, 10, 26, 10, 0, 0, 0, 13, 73, 72, 68, 82 };
        private static readonly byte[] PDF = { 37, 80, 68, 70, 45, 49, 46 };
        private static readonly byte[] DOC = { 208, 207 };
        private static readonly byte[] ZIP_DOCX = { 80, 75, 3, 4 };
        private static readonly byte[] TXT = { 0 };
        private static readonly byte[] TXT_UTF8 = { 239, 187, 191 };
        private static readonly byte[] TXT_UTF16_BE = { 254, 255 };
        private static readonly byte[] TXT_UTF16_LE = { 255, 254 };
        private static readonly byte[] TXT_UTF32_BE = { 0, 0, 254, 255 };
        private static readonly byte[] TXT_UTF32_LE = { 255, 254, 0, 0 };

        public MimeMappingService(FileExtensionContentTypeProvider contentTypeProvider)
        {
            _contentTypeProvider = contentTypeProvider;
        }
        public string Map(string fileName)
        {
            string contentType;
            var x = _contentTypeProvider.Mappings;
            if (!_contentTypeProvider.TryGetContentType(fileName, out contentType))
            {
                //if can't find content type ,set content type to "application/octet-stream". 
                contentType = "application/octet-stream";
            }
            return contentType;
        }

        public string GetMimeType(byte[] file, string fileName)
        {
            var mime = "application/octet-stream"; //DEFAULT UNKNOWN MIME TYPE
            //var x = ContentInfo.GetContentType(file);
            //string mimeType = MimeUtility.GetMimeMapping(fileName);
            //var f = new FileInfo(fileName);

            if (string.IsNullOrWhiteSpace(fileName))
            {
                return mime;
            }

            string extension = Path.GetExtension(fileName) == null
                               ? string.Empty
                               : Path.GetExtension(fileName).ToUpper();

            if (file.Take(3).SequenceEqual(JPG))
            {
                mime = "image/jpeg";
            }
            else if (file.Take(7).SequenceEqual(PDF))
            {
                mime = "application/pdf";
            }
            else if (file.Take(16).SequenceEqual(PNG))
            {
                mime = "image/png";
            }
            else if (file.Take(4).SequenceEqual(ZIP_DOCX))
            {
                mime = extension == ".DOCX" ? "application/vnd.openxmlformats-officedocument.wordprocessingml.document" : "application/x-zip-compressed";
            }
            else if (file.Take(2).SequenceEqual(DOC))
            {
                mime = "application/msword";
            }
            else if (file.Take(1).SequenceEqual(TXT))
            {
                mime = "text/plain";
            }
            else if (file.Take(3).SequenceEqual(TXT_UTF8))
            {
                mime = "text/plain";
            }
            else if (file.Take(2).SequenceEqual(TXT_UTF16_BE))
            {
                mime = "text/plain";
            }
            else if (file.Take(2).SequenceEqual(TXT_UTF16_LE))
            {
                mime = "text/plain";
            }
            else if (file.Take(4).SequenceEqual(TXT_UTF32_BE))
            {
                mime = "text/plain";
            }
            else if (file.Take(4).SequenceEqual(TXT_UTF32_LE))
            {
                mime = "text/plain";
            }
            else
            {
                return mime;
            }

            return mime;
        }

        public byte[] FileToByteArray(string url)
        {
            //using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
            //{
            //    // Create a byte array of file stream length
            //    byte[] bytes = System.IO.File.ReadAllBytes(filename);
            //    //Read block of bytes from stream into the byte array
            //    fs.Read(bytes, 0, System.Convert.ToInt32(fs.Length));
            //    //Close the File Stream
            //    fs.Close();
            //    return bytes; //return the byte data
            //}
            var Client = new WebClient();
            var trueUrl = HttpUtility.UrlDecode(url);
            return Client.DownloadData(trueUrl);

        }
    }
}