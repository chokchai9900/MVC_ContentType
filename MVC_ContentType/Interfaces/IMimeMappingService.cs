using MVC_ContentType.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_ContentType.Interfaces
{
    public interface IMimeMappingService
    {
        string Map(string fileName);
        ContentTypeModel GetMimeType(byte[] file, string fileName);
        byte[] FileToByteArray(string url);
    }
}
