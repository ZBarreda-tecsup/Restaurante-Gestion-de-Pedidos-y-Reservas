using CasoSemana5.Models;
using CasoSemana5.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CasoSemana5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantTablesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public RestaurantTablesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TableRestaurant>>> GetTables()
        {
            var tables = await _unitOfWork.Tables.GetAllAsync();
            return Ok(tables);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TableRestaurant>> GetTable(string id)
        {
            var table = await _unitOfWork.Tables.GetByIdAsync(id);
            if (table == null)
            {
                return NotFound();
            }
            return Ok(table);
        }

        [HttpPost]
        public async Task<ActionResult<TableRestaurant>> PostTable(TableRestaurant table)
        {
            await _unitOfWork.Tables.AddAsync(table);
            await _unitOfWork.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTable), new { id = table.Id }, table);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTable(string id, TableRestaurant table)
        {
            if (id != table.Id.ToString())
            {
                return BadRequest();
            }
            await _unitOfWork.Tables.UpdateAsync(table);
            await _unitOfWork.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTable(string id)
        {
            var table = await _unitOfWork.Tables.GetByIdAsync(id);
            if (table == null)
            {
                return NotFound();
            }
            await _unitOfWork.Tables.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
            return NoContent();
        }
    }
}

