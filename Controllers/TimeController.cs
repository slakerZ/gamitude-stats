using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectsApi.Dto.TimeSpend;
using StatsApi.BusinessLogic;
using StatsApi.Dto;
using StatsApi.Models;
using StatsApi.Services;

namespace StatsApi.Controllers
{
    [Route("[controller]")]
    [Authorize]
    [ApiController]
    public class TimeController : ControllerBase
    {

        private readonly ILogger<StatsController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ITimeManager _timeManager;

        public TimeController(ILogger<StatsController> logger, IHttpContextAccessor httpContextAccessor
                                ,ITimeManager timeManager)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _timeManager = timeManager;
        }
//RETURN STATUS CLASS????
        [HttpPost]
        public ActionResult<ControllerResponse<CreateTimeSpend>> Create(CreateTimeSpend timeSpend)
        {
            return Ok();
        }

    }
}
