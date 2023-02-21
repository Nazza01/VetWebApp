using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VetWebApp.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("VetWebAppContextConnection") ?? throw new InvalidOperationException("Connection string 'VetWebAppContextConnection' not found.");

builder.Services.AddDbContext<VetWebAppContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<VetWebAppContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add Hot Reload
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

// Configure the W3C Logger middleware
builder.Services.AddW3CLogging(logging =>
{
    logging.LoggingFields = Microsoft.AspNetCore.HttpLogging.W3CLoggingFields.All;

    
    logging.FileSizeLimit = 5 * 1024 * 1024;
    logging.RetainedFileCountLimit = 2;
    logging.FileName = "VetWebAppLog_";
    logging.LogDirectory = "Logs";
    logging.FlushInterval = TimeSpan.FromSeconds(2);
});

var app = builder.Build();

//  Enable use of W3C Logging
app.UseW3CLogging();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

//  Refer to static files so we can use the path ~/Content instead of absolute path
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath, "Content")),
    RequestPath = "/Content"
});

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Home}/{id?}");
app.MapRazorPages();

app.Run();

