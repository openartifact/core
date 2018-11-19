using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace openartifact_core.Controllers
{
    [Route("api")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        [Route("metadata")]
        
        public Metadata Metadata()
        {
            string steamID = null;
            // Console.WriteLine(this.HttpContext.User.Identity?.Name);
            if (this.HttpContext.User.Claims.Count() > 0)
            {
                steamID = this.HttpContext.User.Claims.First().Value.Split('/').LastOrDefault();
            }
            return new Metadata{ TestProperty = "Hello World", Identifier = steamID, IsAuthenticated = this.HttpContext.User.Identity.IsAuthenticated };
        }
    }
}
