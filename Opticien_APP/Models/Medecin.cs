csharp
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Opticien_APP.Models
{
    public class Medecin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required(ErrorMessage = "Le nom est obligatoire.")]
        public string nom { get; set; }

        [Required(ErrorMessage = "Le prénom est obligatoire.")]
        public string prenom { get; set; }

        [Required(ErrorMessage = "Le numéro de téléphone est obligatoire.")]
        [StringLength(10, ErrorMessage = "Le numéro de téléphone ne doit pas dépasser 10 caractères.")]
        public string gsm { get; set; }
    }
}