using Microsoft.EntityFrameworkCore;

namespace CosmeticsManagement.Model.Contexts
{    
    public class Context<T> : DbContext where T : class
    {        
        public DbSet<T> DataContainer { get; set; }                
     
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = ConnectionHelper.ConnectionString;
            optionsBuilder.UseJet(connectionString);
        }
    }
}
