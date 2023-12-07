using Lab11.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace Lab11.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly OktaApiService _oktaApiService;

        public ProfileController(IConfiguration configuration)
        {
            _oktaApiService = new OktaApiService(configuration["Okta:apiToken"] ?? "007HVXTIGtbPTvbQ3NQAoD7IGYCPu7A2GVq5ZnG0jj", configuration);
        }

        [HttpGet("get-user-info")]
        public async Task<IActionResult> GetProfileInfo()
        {
            var user = await _oktaApiService.GetUserAsync(User.Claims.FirstOrDefault(x => x.Type == "uid")?.Value ?? string.Empty);

            return Ok(user);
        }
    }
}
