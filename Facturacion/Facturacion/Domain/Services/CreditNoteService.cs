using Facturacion.DAL.Entities;
using Facturacion.DAL;
using Microsoft.EntityFrameworkCore;
using Facturacion.Domain.Interfaces;

namespace Facturacion.Domain.Services
{
    public class CreditNoteService : ICreditNoteService
    {
        private readonly DataBaseContext _context;

        public CreditNoteService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CreditNote>> GetCreditNoteAsync()
        {
            var creditNote = await _context.CreditNotes.ToListAsync();
            return creditNote;
        }

        public async Task<CreditNote> GetCreditNoteByIdAsync(Guid id)
        {
            var creditNote = await _context.CreditNotes.FirstOrDefaultAsync(c => c.Id == id);
            return creditNote;
        }

        public async Task<CreditNote> CreateCreditNoteAsync(CreditNote creditNote)
        {
            try
            {
                creditNote.Id = Guid.NewGuid();
                //value
                //document
                creditNote.CreatedDate = DateTime.Now;
                _context.CreditNotes.Add(creditNote);
                //Motive

                await _context.SaveChangesAsync();
                return creditNote;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<CreditNote> EditCreditNoteAsync(CreditNote creditNote)
        {
            creditNote.ModifiedDate = DateTime.Now;
            _context.CreditNotes.Update(creditNote);
            await _context.SaveChangesAsync();
            return creditNote;
        }

        public async Task<CreditNote> DeleteCreditNoteAsync(Guid id)
        {
            var creditNote = await GetCreditNoteByIdAsync(id);

            if (creditNote== null) return null;

            _context.CreditNotes.Remove(creditNote);
            await _context.SaveChangesAsync();

            return creditNote;
        }
    }
}
