using Microsoft.EntityFrameworkCore;
using WebApplicationwithScrapping.Models;
namespace WebApplicationwithScrapping.DataModels
{
	public class Context:DbContext
	{
        public Context()
        {
        }
        public DbSet<Database>? Databases { get; set; }
        public DbSet<Class>? Class { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("server=SILA\\MSSQLSERVER02;database=Deneme;integrated security=true;");
		}
    }
}
