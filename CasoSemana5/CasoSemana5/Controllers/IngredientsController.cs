using CasoSemana5.Models;
using CasoSemana5.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CasoSemana5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public IngredientsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ingredient>>> GetIngredients()
        {
            var ingredients = await _unitOfWork.Ingredients.GetAllAsync();
            return Ok(ingredients);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ingredient>> GetIngredient(string id)
        {
            var ingredient = await _unitOfWork.Ingredients.GetByIdAsync(id);
            if (ingredient == null)
            {
                return NotFound();
            }
            return Ok(ingredient);
        }

        [HttpPost]
        public async Task<ActionResult<Ingredient>> PostIngredient(Ingredient ingredient)
        {
            await _unitOfWork.Ingredients.AddAsync(ingredient);
            await _unitOfWork.SaveChangesAsync();
            return CreatedAtAction(nameof(GetIngredient), new { id = ingredient.Id }, ingredient);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutIngredient(string id, Ingredient ingredient)
        {
            if (id != ingredient.Id.ToString())
            {
                return BadRequest();
            }
            await _unitOfWork.Ingredients.UpdateAsync(ingredient);
            await _unitOfWork.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIngredient(string id)
        {
            var ingredient = await _unitOfWork.Ingredients.GetByIdAsync(id);
            if (ingredient == null)
            {
                return NotFound();
            }
            await _unitOfWork.Ingredients.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
            return NoContent();
        }
    }
}

