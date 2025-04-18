csharp
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Opticien_APP.Models
{
    public class Ordonnance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public DateTime DateDePrescription { get; set; }

        public string OD_VL_SPH { get; set; }
        public string OD_VL_CYL { get; set; }
        public string OD_VL_AXE { get; set; }
        public string OD_VL_ADD { get; set; }
        public string OD_VL_EP { get; set; }
        public string OD_VL_H { get; set; }
        public string OD_VL_DAIM { get; set; }
        public string OG_VL_SPH { get; set; }
        public string OG_VL_CYL { get; set; }
        public string OG_VL_AXE { get; set; }
        public string OG_VL_ADD { get; set; }
        public string OG_VL_EP { get; set; }
        public string OG_VL_H { get; set; }
        public string OG_VL_DAIM { get; set; }
        public string OD_VP_SPH { get; set; }
        public string OD_VP_CYL { get; set; }
        public string OD_VP_AXE { get; set; }
        public string OD_VP_ADD { get; set; }
        public string OD_VP_EP { get; set; }
        public string OD_VP_H { get; set; }
        public string OD_VP_DAIM { get; set; }
        public string OG_VP_SPH { get; set; }
        public string OG_VP_CYL { get; set; }
        public string OG_VP_AXE { get; set; }
        public string OG_VP_ADD { get; set; }
        public string OG_VP_EP { get; set; }
        public string OG_VP_H { get; set; }
        public string OG_VP_DAIM { get; set; }

        [Required]
        [ForeignKey("Medecin")]
        public int medecinID { get; set; }
        public virtual Medecin Medecin { get; set; }
    }
}