using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UserData.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add Hot Reload
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddDbContext<UserDataContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("UserDataContext") ?? throw new InvalidOperationException("Connection string 'UserDataContext' not found.")));

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

