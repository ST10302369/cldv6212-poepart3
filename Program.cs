using CloudPart3.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using CloudPart3.Services;

var builder = WebApplication.CreateBuilder(args);

// Access the configuration object
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register BlobService with configuration
builder.Services.AddSingleton(new BlobService(configuration.GetConnectionString("AzureStorage")));


// Register QueueService with configuration
builder.Services.AddSingleton<QueueService>(sp =>
{
    var connectionString = configuration.GetConnectionString("AzureStorage");
    return new QueueService(connectionString); // Pass connection string only
});

// Register FileShareService with configuration
builder.Services.AddSingleton<AzureFileShareService>(sp =>
{
    var connectionString = configuration.GetConnectionString("AzureStorage");
    return new AzureFileShareService(connectionString, "contractsshare");
});


//Adding DB Context builder services with options
//builder.Services.AddDbContext<ApplicationDBContext>(options =>
//           options.UseSqlServer(builder.Configuration.GetConnectionString("ABCRetailersDEV")));

builder.Services.AddDbContext<ApplicationDBContext>(options =>
           options.UseSqlServer(builder.Configuration.GetConnectionString("ABCRetailersLive")));

//Added service for Authorization for Role based Access
builder.Services.AddDefaultIdentity<IdentityUser>().AddDefaultTokenProviders()
               .AddRoles<IdentityRole>()
               .AddEntityFrameworkStores<ApplicationDBContext>();


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

app.MapRazorPages();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



















































































app.Run();