using CasoSemana5.Models;
using CasoSemana5.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CasoSemana5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public RecipesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recipe>>> GetRecipes()
        {
            var recipes = await _unitOfWork.Recipes.GetAllAsync();
            return Ok(recipes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Recipe>> GetRecipe(string id)
        {
            var recipe = await _unitOfWork.Recipes.GetByIdAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }
            return Ok(recipe);
        }

        [HttpPost]
        public async Task<ActionResult<Recipe>> PostRecipe(Recipe recipe)
        {
            await _unitOfWork.Recipes.AddAsync(recipe);
            await _unitOfWork.SaveChangesAsync();
            return CreatedAtAction(nameof(GetRecipe), new { id = recipe.Id }, recipe);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecipe(string id, Recipe recipe)
        {
            if (id != recipe.Id.ToString())
            {
                return BadRequest();
            }
            await _unitOfWork.Recipes.UpdateAsync(recipe);
            await _unitOfWork.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipe(string id)
        {
            var recipe = await _unitOfWork.Recipes.GetByIdAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }
            await _unitOfWork.Recipes.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
            return NoContent();
        }
    }
}

