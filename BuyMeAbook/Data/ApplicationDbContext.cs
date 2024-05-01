using BuyMeAbook.Models;
using Microsoft.EntityFrameworkCore;

namespace BuyMeAbook.Data
{
    public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)  //configure DB context
        {
            
        }
        public DbSet<Category> Categories { get; set; }  //creating table Categories using Dbset model and passing the model
    }
}
