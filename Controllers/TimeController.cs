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
    public class TimeController : ControllerBase
    {

        private readonly ILogger<StatsController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly StatsService _statsService;

        public TimeController(ILogger<StatsController> logger, IHttpContextAccessor httpContextAccessor,StatsService statsService)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _statsService = statsService;
        }

        [HttpGet]
        public ActionResult<Stats> Get()
        {
            string userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name).ToString();
            if (null != userId)
            {
                return _statsService.GetStatsByUserId(userId);
            }
            else
            {
                return NotFound("User Failure");

            }
        }
        [HttpPost]
        public ActionResult<Stats> Create(Stats stats)
        {
            string userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name).ToString();
            if (null != userId)
            {
                stats.UserId = userId;
                _statsService.Create(stats);
                return CreatedAtRoute("Create Stats", new { id = stats.Id.ToString() }, stats);
            }
            else
            {
                return NotFound("User Failure");
            }
        }

    }
}
