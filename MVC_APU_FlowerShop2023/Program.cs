using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MVC_APU_FlowerShop2023.Areas.Identity.Data;
using MVC_APU_FlowerShop2023.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("MVC_APU_FlowerShop2023ContextConnection") ?? throw new InvalidOperationException("Connection string 'MVC_APU_FlowerShop2023ContextConnection' not found.");

builder.Services.AddDbContext<MVC_APU_FlowerShop2023Context>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<MVC_APU_FlowerShop2023User>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<MVC_APU_FlowerShop2023Context>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
