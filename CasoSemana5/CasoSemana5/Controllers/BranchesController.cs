using CasoSemana5.Models;
using CasoSemana5.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CasoSemana5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public BranchesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Branches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Branch>>> GetBranches()
        {
            var branches = await _unitOfWork.Branches.GetAllAsync();
            return Ok(branches);
        }

        // GET: api/Branches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Branch>> GetBranch(string id)
        {
            var branch = await _unitOfWork.Branches.GetByIdAsync(id);

            if (branch == null)
            {
                return NotFound();
            }

            return Ok(branch);
        }

        // POST: api/Branches
        [HttpPost]
        public async Task<ActionResult<Branch>> PostBranch(Branch branch)
        {
            await _unitOfWork.Branches.AddAsync(branch);
            await _unitOfWork.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBranch), new { id = branch.Id }, branch);
        }

        // PUT: api/Branches/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBranch(string id, Branch branch)
        {
            // CORRECCIÓN: Se convierte el Guid del objeto a string para poder compararlo.
            if (id != branch.Id.ToString())
            {
                return BadRequest();
            }

            await _unitOfWork.Branches.UpdateAsync(branch);
            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Branches/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBranch(string id)
        {
            var branch = await _unitOfWork.Branches.GetByIdAsync(id);
            if (branch == null)
            {
                return NotFound();
            }

            await _unitOfWork.Branches.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }
    }
}

