using Lab11.Models;
using Lab4Classes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab11.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class LabsController : ControllerBase
    {
        [HttpPost("calculate")]
        public IActionResult Calculate(LabModel model)
        {
            try
            {
                model.Output = Runner.RunLab(model.LabNumber, model.Input);

                return Ok(model);
            }
            catch (Exception e)
            {
                model.Output = $"Error: {e.Message}";

                return Ok(model);
            }

        }
    }
}
