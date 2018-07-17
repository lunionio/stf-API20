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
            optionsBuilder.UseSqlServer(@"Data Source=34.226.175.244;Initial Catalog=StaffPro_Dev2;Persist Security Info=True;User ID=sa;Password=StaffPro@123;");
        }
    }
}