csharp
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Opticien_APP.Models
{
    public class OperationVente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public string NumeroOp { get; set; }

        [Required]
        public DateTime DateDeVente { get; set; }

        [Required]
        public DateTime DateLivrisonprevu { get; set; }

        [Required]
        public string Remarque { get; set; }

        public decimal? Montant { get; set; }

        [ForeignKey("Client")]
        public int clientID { get; set; }
        public virtual Client Client { get; set; }

        [ForeignKey("Ordonnance")]
        public int OrdID { get; set; }
        public virtual Ordonnance Ordonnance { get; set; }
    }
}