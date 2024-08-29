using Microsoft.AspNetCore.Mvc;

namespace ExpenseManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("ServerConnection")]
        public async Task<ActionResult<String>> GetExample()
        {
            return "Server is run...";
        }

    }
}
