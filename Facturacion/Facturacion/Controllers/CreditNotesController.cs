using Facturacion.DAL.Entities;
using Facturacion.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Facturacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditNotesController:Controller
    {
            private readonly ICreditNoteService _creditNoteService;

            public CreditNotesController(ICreditNoteService creditNoteService)
            {
                _creditNoteService = creditNoteService;
            }

            [HttpGet, ActionName("Get")]
            [Route("GetAll")]
            public async Task<ActionResult<IEnumerable<CreditNote>>> GetCreditNoteAsync()
            {
                var CreditNotes = await _creditNoteService.GetCreditNoteAsync();
                if (CreditNotes== null || !CreditNotes.Any())
                {
                    return NotFound();
                }
                return Ok(CreditNotes);
            }

            [HttpGet, ActionName("Get")]
            [Route("GetById/{id}")]
            public async Task<ActionResult<CreditNote>> GetCreditNoteByIdsAsync(Guid id)
            {
                var creditNote= await _creditNoteService.GetCreditNoteByIdAsync(id);
                if (creditNote== null)
                {
                    return NotFound();
                }
                return Ok(creditNote);
            }

            [HttpPost, ActionName("Create")]
            [Route("Create")]
            public async Task<ActionResult<CreditNote>> CreateCreditNoteAsync(CreditNote creditNote)
            {
                try
                {
                    var newCreateNote = await _creditNoteService.CreateCreditNoteAsync(creditNote);
                    if (newCreateNote == null)
                    {
                        return NotFound();
                    }
                    return Ok(newCreateNote);
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("duplicate"))
                    {
                        return Conflict(String.Format("{0} ya existe", creditNote.Document));
                    }
                    return Conflict(ex.Message);
                }
            }

            [HttpPut, ActionName("Edit")]
            [Route("Edit")]
            public async Task<ActionResult<CreditNote>> EditCreditNoteAsync(CreditNote creditNote)
            {
                try
                {
                    var editedCreditNote = await _creditNoteService.EditCreditNoteAsync(creditNote);
                    if (editedCreditNote== null)
                    {
                        return NotFound();
                    }
                    return Ok(editedCreditNote);
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("duplicate"))
                    {
                        return Conflict(String.Format("{0} ya existe", creditNote.Document));
                    }
                    return Conflict(ex.Message);
                }
            }

            [HttpPut, ActionName("Delete")]
            [Route("Delete")]
            public async Task<ActionResult<CreditNote>> DeleteCreditNoteAsync(Guid id)
            {
                if (id == null) return BadRequest();

                var deletedCreditNote = await _creditNoteService.DeleteCreditNoteAsync(id);
                if (deletedCreditNote== null)
                {
                    return NotFound();
                }
                return Ok(deletedCreditNote);
            }
        }
}
