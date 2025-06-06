using System.ComponentModel.DataAnnotations;

namespace Facturacion.DAL.Entities
{
    public class AuditBase
    {
        [Key]
        [Required]
        public virtual Guid Id { get; set; }

        [Required]
        public virtual string? Document { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "El valor debe ser Positivo")]
        [Required(ErrorMessage = "Debe ingresar un valor")]
        public int Value { get; set; }

        public virtual DateTime? CreatedDate { get; set; }
        public virtual DateTime? ModifiedDate { get; set; }

        

    }
}
