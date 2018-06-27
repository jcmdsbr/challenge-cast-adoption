using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SGA.Infra.CrossCutting.Identity.Models;

namespace SGA.Infra.CrossCutting.Identity.Context
{
    public class SgaIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public SgaIdentityDbContext(DbContextOptions<SgaIdentityDbContext> options) : base(options)
        {
            // Database.EnsureCreated();
        }

    }
}
