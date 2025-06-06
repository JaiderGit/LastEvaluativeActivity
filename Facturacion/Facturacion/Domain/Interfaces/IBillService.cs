using Facturacion.DAL.Entities;

namespace Facturacion.Domain.Interfaces
{
    public interface IBillService
    {
        Task<IEnumerable<Bill>> GetBillAsync(); //Todas las facturas

        Task<Bill> CreateBillAsync(Bill bill); //

        Task<Bill> GetBillByIdAsync(Guid id);

        Task<Bill> EditBillAsync(Bill bill);

        Task<Bill> DeleteBillAsync(Guid id);

    }
}
