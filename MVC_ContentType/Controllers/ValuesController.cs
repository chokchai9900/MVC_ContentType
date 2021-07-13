using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using MVC_ContentType.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MVC_ContentType.Controllers
{
    /// <summary>
    /// ValuesController
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        private readonly IMimeMappingService _mimeMappingService;

        public ValuesController(IMimeMappingService mimeMappingService)
        {
            _mimeMappingService = mimeMappingService;
        }

        /// <summary>
        /// GetContentType
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        //[HttpGet("{fileName}")]
        //public string GetContentType(string fileName)
        //{
        //    return _mimeMappingService.Map(fileName);
        //}
        /// <summary>
        /// GetContentTypeByUrl
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        [HttpGet("{url}")]
        public string GetContentTypeByUrl(string url)
        {
            var getName = "";
            if (url.Contains('/'))
            {
                getName = url.Split('/').Last();
            }
            else
            {
                getName = url.Split("%2F").Last();
            }
            var getbyte = _mimeMappingService.FileToByteArray(url);
            return _mimeMappingService.GetMimeType(getbyte,getName).Mime;
        }
    }
}
