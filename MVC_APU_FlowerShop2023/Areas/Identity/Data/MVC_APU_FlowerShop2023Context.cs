using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVC_APU_FlowerShop2023.Areas.Identity.Data;
using MVC_APU_FlowerShop2023.Models;

namespace MVC_APU_FlowerShop2023.Data;

public class MVC_APU_FlowerShop2023Context : IdentityDbContext<MVC_APU_FlowerShop2023User>
{
    public MVC_APU_FlowerShop2023Context(DbContextOptions<MVC_APU_FlowerShop2023Context> options)
        : base(options)
    {
    }

    public DbSet<Flower> FlowerTable { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
