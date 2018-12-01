using Microsoft.EntityFrameworkCore;
using Welfare.Models;

namespace Welfare.Data
{
    /// <summary>
    /// PM> Add-Migration WelfareDbCreate -Context Welfare.Data.WelfareDbContext -OutputDir Data/Migrations
    /// PM> Update-Database -Context Welfare.Data.WelfareDbContext
    /// </summary>
    public class WelfareDbContext : DbContext
    {
        public WelfareDbContext(DbContextOptions<WelfareDbContext> options) : base(options)
        {

        }

        public DbSet<Guardian> Guardians { get; set; }
    }
}
