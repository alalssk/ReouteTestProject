using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ReouteTest.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TestController : Controller
    {
        [HttpPost]
        [Route("echo")]
        public async Task<IActionResult> Echo()
        {
            string retBody;
            HttpContext.Request.EnableBuffering();
            using (var reader = new StreamReader(
                Request.Body,
                encoding: System.Text.Encoding.UTF8,
                detectEncodingFromByteOrderMarks: false,
                bufferSize: 1024,
                leaveOpen: true
            ))
            {
                retBody = await reader.ReadToEndAsync();
            }

            return Json(retBody);
        }

    }
}
