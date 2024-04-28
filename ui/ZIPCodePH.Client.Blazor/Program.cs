using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ZIPCodePH.Client.Blazor.Components;
using ZIPCodePH.Client.Blazor.Data;
using ZIPCodePH.DataContext.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddApplicationContext();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddBlazorBootstrap();
builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseMigrationsEndPoint();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();