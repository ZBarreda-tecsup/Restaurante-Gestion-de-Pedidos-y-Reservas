using CasoSemana5.Models;
using CasoSemana5.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CasoSemana5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReservationsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reservation>>> GetReservations()
        {
            var reservations = await _unitOfWork.Reservations.GetAllAsync();
            return Ok(reservations);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Reservation>> GetReservation(string id)
        {
            var reservation = await _unitOfWork.Reservations.GetByIdAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }
            return Ok(reservation);
        }

        [HttpPost]
        public async Task<ActionResult<Reservation>> PostReservation(Reservation reservation)
        {
            await _unitOfWork.Reservations.AddAsync(reservation);
            await _unitOfWork.SaveChangesAsync();
            return CreatedAtAction(nameof(GetReservation), new { id = reservation.Id }, reservation);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutReservation(string id, Reservation reservation)
        {
            if (id != reservation.Id.ToString())
            {
                return BadRequest();
            }
            await _unitOfWork.Reservations.UpdateAsync(reservation);
            await _unitOfWork.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation(string id)
        {
            var reservation = await _unitOfWork.Reservations.GetByIdAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }
            await _unitOfWork.Reservations.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
            return NoContent();
        }
    }
}

