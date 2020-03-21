using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace StatsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RanksController : ControllerBase
    {

        private readonly ILogger<RanksController> _logger;

        public RanksController(ILogger<RanksController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
