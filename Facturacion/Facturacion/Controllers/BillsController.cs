using Facturacion.DAL.Entities;
using Facturacion.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Facturacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class BillsController : Controller
    {
        private readonly IBillService _billService;

        public BillsController(IBillService billService)
        {
            _billService = billService;
        }

        [HttpGet,ActionName("Get")]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<Bill>>> GetBillsAsync()
        {
            var bills=await _billService.GetBillAsync();
            if (bills == null || !bills.Any())
            {
                return NotFound();
            }
            return Ok(bills);
        }

        [HttpGet, ActionName("Get")]
        [Route("GetById/{id}")]
        public async Task<ActionResult<Bill>> GetBillByIdsAsync(Guid id)
        {
            var bill = await _billService.GetBillByIdAsync(id);
            if (bill == null)
            {
                return NotFound();
            }
            return Ok(bill);
        }

        [HttpPost, ActionName("Create")]
        [Route("Create")]
        public async Task<ActionResult<Bill>> CreateBillAsync(Bill bill)
        {
            try
            {
                var newBill = await _billService.CreateBillAsync(bill);
                if(newBill == null)
                {
                    return NotFound();
                }
                return Ok(newBill);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate")) 
                {
                    return Conflict(String.Format("{0} ya existe", bill.Document));
                }
                return Conflict(ex.Message);
            }
        }

        [HttpPut, ActionName("Edit")]
        [Route("Edit")]
        public async Task<ActionResult<Bill>> EditBillAsync(Bill bill)
        {
            try
            {
                var editedBill = await _billService.EditBillAsync(bill);
                if (editedBill == null)
                {
                    return NotFound();
                }
                return Ok(editedBill);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                {
                    return Conflict(String.Format("{0} ya existe", bill.Document));
                }
                return Conflict(ex.Message);
            }
        }

        [HttpPut, ActionName("Delete")]
        [Route("Delete")]
        public async Task<ActionResult<Bill>> DeleteBillAsync(Guid id)
        {
            if (id == null) return BadRequest();

                var deletedBill = await _billService.DeleteBillAsync(id);
                if (deletedBill == null)
                {
                    return NotFound();
                }
                return Ok(deletedBill);  
        }

    }
}
