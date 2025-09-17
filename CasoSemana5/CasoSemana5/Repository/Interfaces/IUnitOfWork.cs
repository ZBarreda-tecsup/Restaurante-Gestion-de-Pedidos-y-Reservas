using System.Threading.Tasks;

namespace CasoSemana5.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        IBranchRepository Branches { get; }
        ICustomerRepository Customers { get; }
        IIngredientRepository Ingredients { get; }
        IInventoryMovementRepository InventoryMovements { get; }
        IInvoiceRepository Invoices { get; }
        IMenuItemRepository MenuItems { get; }
        IOrderItemRepository OrderItems { get; }
        IOrderRestaurantRepository Orders { get; }
        IPaymentRepository Payments { get; }
        IRecipeRepository Recipes { get; }
        IReservationRepository Reservations { get; }
        ISystemUserRepository SystemUsers { get; }
        ITableRestaurantRepository Tables { get; }

        Task<int> SaveChangesAsync();
    }
}