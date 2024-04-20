using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.DependencyInjection;
using ZIPCodePH.Common.Models;
using ZIPCodePH.Data.Old.Data;
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
        await SeedAreaDataAsync(context, Areas.Ncr, ncr);
        await SeedAreaDataAsync(context, Areas.Luzon, luzon);
        await SeedAreaDataAsync(context, Areas.Visayas, visayas);
        await SeedAreaDataAsync(context, Areas.Mindanao, mindanao);

        // ZIP Codes
        await SeedZipCodeDataAsync(context, ZipCodes.All);

        await context.SaveChangesAsync();
    }

    private static async Task SeedZipCodeDataAsync(
        ApplicationContext context,
        IEnumerable<ZipCodeModel> data)
    {
        foreach (var zipCode in data)
        {
            Console.WriteLine($"{zipCode.Area} {zipCode.Town}");

            var area = context.ChangeTracker.Entries<Area>().FirstOrDefault(e => e.Entity.Name == zipCode.AreaName);
            var code = ushort.Parse(zipCode.ZipCode);
            await context.AddAsync(new ZipCode
                {
                    Code = code,
                    Town = zipCode.Town,
                    Area = area!.Entity,
                }
            );
        }
    }

    private static async Task SeedAreaDataAsync(
        ApplicationContext context,
        IEnumerable<string> areas,
        EntityEntry<Group> group)
    {
        foreach (var area in areas)
        {
            await context.AddAsync(
                new Area { Name = area, Group = group.Entity });
        }
    }

}