csharp
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Opticien_APP.Models
{
    public class Verres
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required(ErrorMessage = "The Type De Verre is Required")]
        [Display(Name = "Type De Verre")]
        public string TypeDeVerre { get; set; }
    }
}