using CasoSemana5.Models;
using CasoSemana5.Repository.Interfaces;

namespace CasoSemana5.Repository.Classes
{
    public class OrderItemRepository : Repository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(AppDbContext context) : base(context)
        {
        }
    }
}