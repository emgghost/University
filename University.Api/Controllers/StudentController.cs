using Microsoft.AspNetCore.Mvc;

namespace University.Api.Controllers;

public class StudentController : BaseApiController
{
    [HttpPost("Add")]
    public async Task<IActionResult> Index()
    {
        return Ok();
    }
}