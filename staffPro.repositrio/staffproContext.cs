using Microsoft.EntityFrameworkCore;
using staffpro.entity;
namespace staffPro.repository
{
    public class staffproContext : DbContext
    {
        public DbSet<Oportunidade> Oportunidade { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseSqlServer(@"Server=DESKTOP-9B04LJT\SQLEXPRESS;Database=WebPixPrincipal;Trusted_Connection=True;Integrated Security = True;");
            optionsBuilder.UseSqlServer(@"Data Source = sql.staffpro.com.br; Initial Catalog = StaffPro; Persist Security Info = True; User ID = name; Password = Pass@123; MultipleActiveResultSets = True; Application Name = StaffPro.API");
        }
    }
}