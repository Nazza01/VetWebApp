using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VetWebApp.Areas.Identity.Data;
using VetWebApp.Models;

namespace VetWebApp.Data;

public class VetWebAppContext : IdentityDbContext<VetWebAppUser>
{
    public VetWebAppContext(DbContextOptions<VetWebAppContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

    public DbSet<VetWebApp.Models.AnimalDataModel> AnimalDataModel { get; set; } = default!;
}
