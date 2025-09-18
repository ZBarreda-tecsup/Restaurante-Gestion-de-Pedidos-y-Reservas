using CasoSemana5.Models;
using CasoSemana5.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CasoSemana5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public MenuItemsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuItem>>> GetMenuItems()
        {
            var menuItems = await _unitOfWork.MenuItems.GetAllAsync();
            return Ok(menuItems);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MenuItem>> GetMenuItem(string id)
        {
            var menuItem = await _unitOfWork.MenuItems.GetByIdAsync(id);
            if (menuItem == null)
            {
                return NotFound();
            }
            return Ok(menuItem);
        }

        [HttpPost]
        public async Task<ActionResult<MenuItem>> PostMenuItem(MenuItem menuItem)
        {
            await _unitOfWork.MenuItems.AddAsync(menuItem);
            await _unitOfWork.SaveChangesAsync();
            return CreatedAtAction(nameof(GetMenuItem), new { id = menuItem.Id }, menuItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMenuItem(string id, MenuItem menuItem)
        {
            if (id != menuItem.Id.ToString())
            {
                return BadRequest();
            }
            await _unitOfWork.MenuItems.UpdateAsync(menuItem);
            await _unitOfWork.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenuItem(string id)
        {
            var menuItem = await _unitOfWork.MenuItems.GetByIdAsync(id);
            if (menuItem == null)
            {
                return NotFound();
            }
            await _unitOfWork.MenuItems.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
            return NoContent();
        }
    }
}

