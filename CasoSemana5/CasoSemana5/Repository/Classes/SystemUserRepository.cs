using CasoSemana5.Models;
using CasoSemana5.Repository.Interfaces;

namespace CasoSemana5.Repository.Classes
{
    public class SystemUserRepository : Repository<SystemUser>, ISystemUserRepository
    {
        public SystemUserRepository(AppDbContext context) : base(context)
        {
        }
    }
}