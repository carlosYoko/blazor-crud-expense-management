using ExpenseManagement.Data;
using ExpenseManagement.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpenseManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("ServerConnection")]
        public async Task<ActionResult<String>> GetExample()
        {
            return "Server is run...";
        }

        [HttpGet("UserConnection")]
        public async Task<ActionResult<string>> GetUserConnection()
        {
            try
            {
                var response = await _context.Users.ToListAsync();
                return "Conexion realizada a la tabla Users!";
            }
            catch (Exception ex)
            {
                return "Error de conexion";
            }
        }

        [HttpPost("NewUser")]
        public async Task<ActionResult<string>> NewUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return "Guardado";
        }
    }
}
