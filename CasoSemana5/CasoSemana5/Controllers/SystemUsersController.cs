using CasoSemana5.Models;
using CasoSemana5.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CasoSemana5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemUsersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public SystemUsersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SystemUser>>> GetSystemUsers()
        {
            var users = await _unitOfWork.SystemUsers.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SystemUser>> GetSystemUser(string id)
        {
            var user = await _unitOfWork.SystemUsers.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<SystemUser>> PostSystemUser(SystemUser user)
        {
            await _unitOfWork.SystemUsers.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSystemUser), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSystemUser(string id, SystemUser user)
        {
            if (id != user.Id.ToString())
            {
                return BadRequest();
            }
            await _unitOfWork.SystemUsers.UpdateAsync(user);
            await _unitOfWork.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSystemUser(string id)
        {
            var user = await _unitOfWork.SystemUsers.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            await _unitOfWork.SystemUsers.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
            return NoContent();
        }
    }
}

