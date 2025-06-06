using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Facturacion.DAL.Entities
{
    public class Bill:AuditBase
    {
        [Required(ErrorMessage ="El campo {0} No debe estar vacio")]
        [Display(Name = "Cliente")]
        public String Client { get; set; }
    }
}
