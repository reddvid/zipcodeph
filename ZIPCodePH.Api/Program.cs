using Microsoft.EntityFrameworkCore;
using ZIPCodePH.DataContext.Database;
using ZIPCodePH.DataContext.Options;
using ZIPCodePH.DataContext.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("ZipCodePH")
    ));

// options.UseSqlServer(builder.Configuration["AzureSqlDb:ConnectionString"])
// options.UseSqlServer(builder.Configuration.GetConnectionString("ZipCodePH"))
//
// var jsonBinMasterKey = builder.Configuration["JsonBin:MasterKey"];
// var jsonBinAccessKey = builder.Configuration["JsonBin:AccessKey"];
// builder.Services.Configure<JsonBinConnectionOptions>(o =>
// {
//     o.MasterKey = jsonBinMasterKey!;
//     o.AccessKey = jsonBinAccessKey!;
// });
builder.Services.AddScoped<IZipCodesService, ZipCodesService>();
builder.Services.AddScoped<IAreasService, AreasService>();
builder.Services.AddScoped<IGroupsService, GroupsService>();
builder.Services.AddScoped<ITriviaService, TriviaService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await Seed.Initialize(services);
}

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true)
    .AllowCredentials());

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();