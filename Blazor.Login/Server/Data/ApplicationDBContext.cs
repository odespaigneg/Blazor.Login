using Blazor.Login.Server.Models;
using Blazor.Login.Shared.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Blazor.Login.Server.Data
{
    public class ApplicationDBContext : IdentityDbContext<User>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        public DbSet<Developer> Developers { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
