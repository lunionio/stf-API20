using Microsoft.EntityFrameworkCore;
using WpOportunidades.Entities;

namespace WpOportunidades.Infrastructure
{
    public class WpOportunidadesContext : DbContext
    {
        public DbSet<Oportunidade> Oportunidades { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=34.226.175.244;Initial Catalog=WebPixOportunidades;Persist Security Info=True;User ID=sa;Password=StaffPro@123;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Oportunidade>(op => 
            {
                op.Property(o => o.Descricao).HasColumnType("varchar(150)");
            });
        }
    }
}
