csharp
using System.Data.Entity;
using System.Configuration;

namespace Opticien_APP.Models
{
    public class OpticienDbContext : DbContext
    {
        public OpticienDbContext() : base(ConfigurationManager.ConnectionStrings["OPTICIEN"].ConnectionString)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Medecin> Medecins { get; set; }
        public DbSet<Ordonnance> Ordonnances { get; set; }
        public DbSet<OperationVente> OperationVentes { get; set; }
        public DbSet<Paiement> Paiements { get; set; }
        public DbSet<Verres> Verres { get; set; }
        public DbSet<LignOpVente> LignOpVentes { get; set; }
        public DbSet<Monture> Montures { get; set; }
    }
}