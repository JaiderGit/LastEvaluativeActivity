using Facturacion.DAL.Entities;

namespace Facturacion.Domain.Interfaces
{
    public interface ICreditNoteService
    {
        Task<IEnumerable<CreditNote>> GetCreditNoteAsync(); 

        Task<CreditNote> CreateCreditNoteAsync(CreditNote creditNote); 

        Task<CreditNote> GetCreditNoteByIdAsync(Guid id);

        Task<CreditNote> EditCreditNoteAsync(CreditNote creditNote);

        Task<CreditNote> DeleteCreditNoteAsync(Guid id);

    }
}
