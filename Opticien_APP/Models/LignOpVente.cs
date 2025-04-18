csharp
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Opticien_APP.Models
{
    public class LignOpVente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public string Reference { get; set; }

        [Required]
        public int Quantite { get; set; }

        [Required]
        public decimal Remise { get; set; }

        [Required]
        public decimal PU { get; set; }

        [Required]
        [ForeignKey("OperationVente")]
        public int OperationVenteID { get; set; }
        public virtual OperationVente OperationVente { get; set; }

        [ForeignKey("Verres")]
        public int VERRESID { get; set; }
        public virtual Verres Verres { get; set; }

    }
}