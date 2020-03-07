using ResumeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ResumeApp.Controllers
{
    public class HomeController : ApiController
    {
        [HttpPost]
        public IHttpActionResult ResumeData(Resume _resumeData)
        {
            return Ok();
        }
    }
}
