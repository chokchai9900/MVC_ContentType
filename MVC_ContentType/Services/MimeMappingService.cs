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
            var _content = new ContentType();
            var dataset = _content.GetType();


            if (string.IsNullOrWhiteSpace(fileName))
            {
                return mime;
            }

            string extension = Path.GetExtension(fileName) == null
                               ? string.Empty
                               : Path.GetExtension(fileName).ToUpper();

            var result = dataset.Find(it => file.Take(it.ByteHeaders.Length).SequenceEqual(it.ByteHeaders));


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