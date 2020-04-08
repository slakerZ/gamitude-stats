using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StatsApi.Models;
using StatsApi.Services;

namespace StatsApi.Controllers
{
    [Route("[controller]")]
    [Authorize]
    [ApiController]
    public class StatsController : ControllerBase
    {

        private readonly ILogger<StatsController> _logger;

        public StatsController(ILogger<StatsController> logger)
        {
            _logger = logger;
        }

        //TODO create endpoints for statistics
    }
}
