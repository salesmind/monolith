using Microsoft.AspNetCore.Mvc;

namespace SalesMind.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AboutController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok();
    }
}
