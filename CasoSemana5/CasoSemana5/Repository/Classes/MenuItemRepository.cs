using CasoSemana5.Models;
using CasoSemana5.Repository.Interfaces;

namespace CasoSemana5.Repository.Classes
{
    public class MenuItemRepository : Repository<MenuItem>, IMenuItemRepository
    {
        public MenuItemRepository(AppDbContext context) : base(context)
        {
        }
    }
}