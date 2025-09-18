using CasoSemana5.Models;
using CasoSemana5.Repository.Interfaces;
using CasoSemana5.Repository.Classes;

namespace CasoSemana5.Repository.Classes
{
    public class BranchRepository : Repository<Branch>, IBranchRepository
    {
        public BranchRepository(AppDbContext context) : base(context)
        {
        }
    }
}