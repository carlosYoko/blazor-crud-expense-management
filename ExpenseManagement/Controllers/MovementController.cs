using ExpenseManagement.Data;
using ExpenseManagement.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpenseManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovementController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MovementController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet("MovementConnection")]
        public async Task<ActionResult<string>> GetUserConnection()
        {
            try
            {
                var response = await _context.Users.ToListAsync();
                return "Conexion realizada a la tabla Movements!";
            }
            catch (Exception ex)
            {
                return "Error de conexion";
            }
        }

        [HttpPost("NewMovement")]
        public async Task<ActionResult<string>> NewMovement(Movement movement)
        {
            _context.Movements.Add(movement);
            await _context.SaveChangesAsync();
            return "Movimiento guardado con exito!";
        }
    }
}
