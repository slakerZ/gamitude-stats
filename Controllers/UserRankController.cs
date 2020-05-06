
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectsApi.Dto.Energy;
using ProjectsApi.Dto.Rank;
using ProjectsApi.Dto.Stats;
using ProjectsApi.Dto.UserRank;
using StatsApi.BusinessLogic;
using StatsApi.Dto;
using StatsApi.Models;
using StatsApi.Services;

namespace StatsApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/stats/[controller]/[action]")]
    public class UserRankController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<UserRankController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserRankService _userRankService;

        public UserRankController(IMapper mapper ,ILogger<UserRankController> logger
        , IHttpContextAccessor httpContextAccessor,IUserRankService userRankService)
        {
            _mapper = mapper;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _userRankService = userRankService;
        }


        [HttpGet]
        public async Task<ActionResult<ControllerResponse<GetRank>>> rank()
        {
            try
            {
                _logger.LogInformation("In GET rank");
                string userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name).ToString();
                if (null != userId)
                {
                    return new ControllerResponse<GetRank>
                    {
                        data = _mapper.Map<GetRank>(await _userRankService.GetUserRankByUserId(userId))
                    };
                }
                else
                {
                    _logger.LogError("In GET rank UserId error");

                    return new ControllerResponse<GetRank>
                    {
                        data = null,
                        message = "UserId error",
                        success = false
                    };
                }

            }
            catch (System.Exception e)
            {
                _logger.LogError("Error cached in UserRankController GET rank {error}", e);

                return new ControllerResponse<GetRank>
                {
                    data = null,
                    message = "something went wrong, sorry:(",
                    success = false
                };
            }
        }



        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<ControllerResponse<String>>> Create(CreateUserRank createUserRank)
        {

            try
            {

                if (null != createUserRank.UserId)
                {
                    await _userRankService.CreateAsync(createUserRank.UserId);
                    return new ControllerResponse<String>
                    {
                        data = createUserRank.UserId
                    };
                }
                else
                {
                    return new ControllerResponse<String>
                    {
                        data = null,
                        message = "UserId error",
                        success = false
                    };
                }

            }
            catch (System.Exception)
            {
                return new ControllerResponse<String>
                {
                    data = null,
                    message = "something went wrong, sorry:(",
                    success = false
                };
            }
        }

    }
}
