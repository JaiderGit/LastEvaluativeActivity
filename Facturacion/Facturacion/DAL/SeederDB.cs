using Facturacion.DAL.Entities;

namespace Facturacion.DAL
{
    public class SeederDB
    {
        private readonly DataBaseContext _context;
        public SeederDB(DataBaseContext context)
        {
            _context = context;
        }

        public async Task SeederAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await BillsNewPeriotAsync();

            await _context.SaveChangesAsync();
        }

        private async Task BillsNewPeriotAsync()
        {
            if (!_context.Bills.Any())
            {
                _context.Bills.Add(new Entities.Bill
                {
                    CreatedDate = DateTime.Now,
                    Document = "MED01",
                    Value = 100000,
                    Client = "Jaider",
                    creditNotes = new List<CreditNote>()
                    {
                        new CreditNote
                        {
                            CreatedDate=DateTime.Now,
                            Motive="Error de Precio",
                            Value=10000
                        }
                    }
                });
                _context.Bills.Add(new Entities.Bill
                {
                    CreatedDate = DateTime.Now,
                    Document = "MED02",
                    Value = 300000,
                    Client = "Alexander"
                });
            }
        }

    }
}
