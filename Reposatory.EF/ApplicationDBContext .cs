using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Model.core;

namespace Reposatory.EF
{
    public class ApplicationDBContext: IdentityDbContext<ApplicationUser>
    {
        public ApplicationDBContext()
        {

        }
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-HAJ3TMI\SQL19;Initial Catalog=El-Zahimer;Integrated Security=True; trust server certificate = true");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relation in modelBuilder.Model.GetEntityTypes().SelectMany(r => r.GetForeignKeys()))
            {
                relation.DeleteBehavior = DeleteBehavior.NoAction;
            }
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Helper>().Ignore(h => h.formFile);
        }
        public DbSet<Helper> Helpers { get; set; }
        public DbSet<Patient> patients { get; set; }
        public DbSet<Alarm> Alarms { get; set; }
        public DbSet<HelpRequest> HelpRequests { get; set; }
        public DbSet<HelperProposal> HelperProposals { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Artical>Articals { get; set; }

        public DbSet<Test> Tests { get; set; }
        public DbSet<Question> questions { get; set; }
        public DbSet<Answer> answers { get; set; }

    }
}