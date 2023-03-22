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
        public DbSet<AspSerag.Models.Pojisteni1>? Pojisteni1 { get; set; }
        public DbSet<AspSerag.Models.Pojisteni2>? Pojisteni2 { get; set; }
        public DbSet<AspSerag.Models.Pojistka>? Pojistka { get; set; }
    }
}