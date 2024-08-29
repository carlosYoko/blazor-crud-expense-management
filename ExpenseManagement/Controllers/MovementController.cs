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

        [HttpGet("GetMovements")]
        public async Task<ActionResult<List<Movement>>> GetMovements()
        {
            var movements = await _context.Movements.Include(u => u.User).ToListAsync();
            return movements;
        }

        [HttpDelete("DeleteMovement")]
        [Route("{id}")]
        public async Task<ActionResult<string>> DeleteMovement(int id)
        {
            var movementToDelete = await _context.Movements.Where(m => m.Id == id).FirstOrDefaultAsync();
            if (movementToDelete == null)
            {
                return NotFound("No existe el movimiento");
            }

            _context.Movements.Remove(movementToDelete);
            await _context.SaveChangesAsync();

            return "Movimiento eliminado!";
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<string>> UpdateMovement(Movement movement)
        {
            var movementToUpdate = await _context.Movements.FindAsync(movement.Id);
            if (movementToUpdate == null)
            {
                return BadRequest("No existe el movimiento");
            }

            movementToUpdate.Date = movement.Date;
            movementToUpdate.Quantity = movement.Quantity;
            movementToUpdate.Type = movement.Type;
            movementToUpdate.Description = movement.Description;
            movementToUpdate.UserId = movement.UserId;

            await _context.SaveChangesAsync();

            return "Movimeinto actualizado";
        }
    }
}
