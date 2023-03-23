using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AspSerag.Models;

namespace AspSerag.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Pojisteni1> Pojisteni1 { get; set; } = default!;
        public DbSet<Pojisteni2> Pojisteni2 { get; set; } = default!;
        public DbSet<Pojistka> Pojistka { get; set; } = default!;
    }
}