using CasoSemana5.Models;
using CasoSemana5.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CasoSemana5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryMovementsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public InventoryMovementsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InventoryMovement>>> GetInventoryMovements()
        {
            var movements = await _unitOfWork.InventoryMovements.GetAllAsync();
            return Ok(movements);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InventoryMovement>> GetInventoryMovement(string id)
        {
            var movement = await _unitOfWork.InventoryMovements.GetByIdAsync(id);
            if (movement == null)
            {
                return NotFound();
            }
            return Ok(movement);
        }

        [HttpPost]
        public async Task<ActionResult<InventoryMovement>> PostInventoryMovement(InventoryMovement movement)
        {
            await _unitOfWork.InventoryMovements.AddAsync(movement);
            await _unitOfWork.SaveChangesAsync();
            return CreatedAtAction(nameof(GetInventoryMovement), new { id = movement.Id }, movement);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutInventoryMovement(string id, InventoryMovement movement)
        {
            if (id != movement.Id.ToString())
            {
                return BadRequest();
            }
            await _unitOfWork.InventoryMovements.UpdateAsync(movement);
            await _unitOfWork.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInventoryMovement(string id)
        {
            var movement = await _unitOfWork.InventoryMovements.GetByIdAsync(id);
            if (movement == null)
            {
                return NotFound();
            }
            await _unitOfWork.InventoryMovements.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
            return NoContent();
        }
    }
}

