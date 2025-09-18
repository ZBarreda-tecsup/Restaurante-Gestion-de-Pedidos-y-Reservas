using CasoSemana5.Models;
using CasoSemana5.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CasoSemana5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderItemsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderItem>>> GetOrderItems()
        {
            var orderItems = await _unitOfWork.OrderItems.GetAllAsync();
            return Ok(orderItems);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderItem>> GetOrderItem(string id)
        {
            var orderItem = await _unitOfWork.OrderItems.GetByIdAsync(id);
            if (orderItem == null)
            {
                return NotFound();
            }
            return Ok(orderItem);
        }

        [HttpPost]
        public async Task<ActionResult<OrderItem>> PostOrderItem(OrderItem orderItem)
        {
            await _unitOfWork.OrderItems.AddAsync(orderItem);
            await _unitOfWork.SaveChangesAsync();
            return CreatedAtAction(nameof(GetOrderItem), new { id = orderItem.Id }, orderItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderItem(string id, OrderItem orderItem)
        {
            if (id != orderItem.Id.ToString())
            {
                return BadRequest();
            }
            await _unitOfWork.OrderItems.UpdateAsync(orderItem);
            await _unitOfWork.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderItem(string id)
        {
            var orderItem = await _unitOfWork.OrderItems.GetByIdAsync(id);
            if (orderItem == null)
            {
                return NotFound();
            }
            await _unitOfWork.OrderItems.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
            return NoContent();
        }
    }
}

