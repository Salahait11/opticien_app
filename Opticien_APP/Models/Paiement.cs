csharp
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Opticien_APP.Models
{
    public class Paiement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required(ErrorMessage = "ModeDePaiement is required.")]
        public string ModeDePaiement { get; set; }

        [Required(ErrorMessage = "Avance is required.")]
        public decimal Avance { get; set; }
        
        [Required(ErrorMessage = "OpVenteID is required.")]

        [ForeignKey("OperationVente")]
        public int OpVenteID { get; set; }

        public virtual OperationVente OperationVente { get; set; }
    }
}