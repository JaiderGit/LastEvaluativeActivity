using System.ComponentModel.DataAnnotations;

namespace Facturacion.DAL.Entities
{
    public class CreditNote : AuditBase
    {
        [Display(Name ="Motivo")]
        [MaxLength(300,ErrorMessage ="El campo {0} debe tener maximo {1} caracteres.")]
        [Required(ErrorMessage ="El campo {0} es obligatorio")]
        public String  Motive { get; set; }

        [Display(Name ="Factura")]
        public Bill? Bill { get; set; }
        [Display(Name ="Id Factura")]
        public Guid BillId { get; set; }
    }
}
