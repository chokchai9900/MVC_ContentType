using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_ContentType.Interfaces
{
    public interface IMimeMappingService
    {
        string Map(string fileName);
        string GetMimeType(byte[] file, string fileName);
        byte[] FileToByteArray(string url);
    }
}
