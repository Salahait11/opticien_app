csharp
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Opticien_APP.Models
{
    public class Monture
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public string marque { get; set; }

        [Required]
        public string couleur { get; set; }

        [Required]
        public string taille { get; set; }

        [Required]
        public decimal Prix { get; set; }

         [Required]
        public int LignOpVenteID { get; set; }
        
        [ForeignKey("LignOpVenteID")]
        public virtual LignOpVente LignOpVente { get; set; }

    }
}