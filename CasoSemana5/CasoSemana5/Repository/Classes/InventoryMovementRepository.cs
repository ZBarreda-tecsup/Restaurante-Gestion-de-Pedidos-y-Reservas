using CasoSemana5.Models;
using CasoSemana5.Repository.Interfaces;

namespace CasoSemana5.Repository.Classes
{
    public class InventoryMovementRepository : Repository<InventoryMovement>, IInventoryMovementRepository
    {
        public InventoryMovementRepository(AppDbContext context) : base(context)
        {
        }
    }
}