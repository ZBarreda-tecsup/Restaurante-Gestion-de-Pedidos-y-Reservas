using CasoSemana5.Models;
using CasoSemana5.Repository.Interfaces;

namespace CasoSemana5.Repository.Classes
{
    public class TableRestaurantRepository : Repository<TableRestaurant>, ITableRestaurantRepository
    {
        public TableRestaurantRepository(AppDbContext context) : base(context)
        {
        }
    }
}