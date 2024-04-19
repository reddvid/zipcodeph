using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ZIPCodePH.DataContext.Entities;

namespace ZIPCodePH.DataContext.Data;

public class Seed
{
    public static async Task Initialize(IServiceProvider serviceProvider)
    {
        await using var context =
            new ApplicationContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationContext>>());
        // await context.Database.EnsureDeletedAsync();
        await context.Database.EnsureCreatedAsync();

        if (await context.ZipCodes!.AnyAsync()) return;

        // Groups
        var ncr = await context.AddAsync(new Group { Name = "NCR" });
        var luzon = await context.AddAsync(new Group { Name = "Luzon" });
        var visayas = await context.AddAsync(new Group { Name = "Visayas" });
        var mindanao = await context.AddAsync(new Group { Name = "Mindanao" });

        // Areas

        #region NCR

        var manila = await context.AddAsync(new Area { Name = "Manila", Group = ncr.Entity });
        var caloocan = await context.AddAsync(new Area { Name = "Caloocan", Group = ncr.Entity });

        #endregion

        #region Mindanao

        var misamisOccidental =
            await context.AddAsync(new Area { Name = "Misamis Occidental", Group = mindanao.Entity });
        var misamisOriental = await context.AddAsync(new Area { Name = "Misamis Oriential", Group = mindanao.Entity });

        #endregion

        // ZIP Codes
        await context.AddAsync(new ZipCode
            { Code = 1000, Town = "Central Post Office", Area = manila.Entity! });
        await context.AddAsync(new ZipCode
            { Code = 1001, Town = "Quiapo", Area = manila.Entity });
        await context.AddAsync(new ZipCode
            { Code = 1002, Town = "Intramuros", Area = manila.Entity });
        await context.AddAsync(new ZipCode
            { Code = 1420, Town = "Kaybiga/Deparo", Area = caloocan.Entity });

        #region Misamis Occidental

        await context.AddAsync(new ZipCode
            { Code = 7206, Town = "Aloran", Area = misamisOccidental.Entity });

        #endregion

        #region Misamis Oriental

        await context.AddAsync(new ZipCode
            { Code = 9005, Town = "Balingasag", Area = misamisOriental.Entity });

        #endregion

        await context.SaveChangesAsync();
    }
}