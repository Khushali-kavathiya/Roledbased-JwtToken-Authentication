using JwtRoleBased.Entities;
using Microsoft.EntityFrameworkCore;
namespace JwtRoleBased.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }
        
        public DbSet<User> Users { get; set; }
            
        
    }
}
#pragma warning restore format