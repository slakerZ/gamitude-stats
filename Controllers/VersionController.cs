using System;
using Microsoft.AspNetCore.Mvc;

namespace AuthorizationApi.Controllers
{
    [Route("api/stats/[controller]")]
    [Route("/")]
    [ApiController]
    public class VersionController : ControllerBase
    {
        private String version = "Gamitude Stats Alpha v0.1";

        public VersionController()
        {

        }

        [HttpGet]
        public ActionResult<String> Version()
        {

            return Created("Version", version);
        }

    }
}