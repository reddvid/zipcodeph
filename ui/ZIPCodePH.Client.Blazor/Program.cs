using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ZIPCodePH.Client.Blazor.Components;
using ZIPCodePH.Client.Blazor.Data;
using ZIPCodePH.DataContext.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                       throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationContext>(
    options => options.UseSqlite(connectionString));
builder.Services.AddApplicationContext();
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// builder.Services.AddScoped(x =>
//     new HttpClient
//     {
//         BaseAddress = new Uri("https://localhost:7171")
//     });
builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();