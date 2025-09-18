using CasoSemana5.Models;
using CasoSemana5.Repository.Interfaces;

namespace CasoSemana5.Repository.Classes
{
    public class InvoiceRepository : Repository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(AppDbContext context) : base(context)
        {
        }
    }
}