using Microsoft.AspNetCore.Mvc;

namespace APIdemo.Controllers;

public class ErrorController : ControllerBase
{
    [Route("/error")]
    public IActionResult Error()
    {
        return Problem();
    }
}
