using Facturacion.DAL;
using Facturacion.DAL.Entities;
using Facturacion.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Facturacion.Domain.Services
{
    public class BillService : IBillService
    {
        private readonly DataBaseContext _context;

        public BillService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Bill>> GetBillAsync()
        {
            var bills= await _context.Bills.ToListAsync();
            return bills;
        }

        public async Task<Bill> GetBillByIdAsync(Guid id)
        {
            var bill = await _context.Bills.FirstOrDefaultAsync(c => c.Id == id);
            return bill;
        }

        public async Task<Bill> CreateBillAsync(Bill bill)
        {
            try
            {
                bill.Id = Guid.NewGuid();
                //value
                //document
                bill.CreatedDate = DateTime.Now;
                _context.Bills.Add(bill);
                //Client

                await _context.SaveChangesAsync();
                return bill;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<Bill> EditBillAsync(Bill bill)
        {
            bill.ModifiedDate = DateTime.Now;
            _context.Bills.Update(bill);
            await _context.SaveChangesAsync();
            return bill;
        }

        public async Task<Bill> DeleteBillAsync(Guid id)
        {
            var bill = await GetBillByIdAsync(id);

            if (bill == null) return null;

             _context.Bills.Remove(bill);
            await _context.SaveChangesAsync();
            
            return bill;
        }

        

        
        
    }
}
