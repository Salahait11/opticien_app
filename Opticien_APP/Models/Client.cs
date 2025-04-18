csharp
using System.ComponentModel.DataAnnotations;

public class Client
{
    public int ID { get; set; }
    [Required(ErrorMessage = "Le nom est obligatoire.")]
    public string Nom { get; set; }
    [Required(ErrorMessage = "Le prénom est obligatoire.")]
    public string Prenom { get; set; }
    public DateTime? DateDeNaissance { get; set; }
    [Required(ErrorMessage = "L'adresse est obligatoire.")]
    public string Adresse { get; set; }
    [Required(ErrorMessage = "Le numéro de téléphone est obligatoire.")]
    [StringLength(10, ErrorMessage = "Le numéro de téléphone doit avoir au maximum 10 caractères.")]
    public string NumeroDeTelephone { get; set; }
}