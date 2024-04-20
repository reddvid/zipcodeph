using Microsoft.EntityFrameworkCore;
using ZIPCodePH.Common.Models;
using ZIPCodePH.DataContext.Entities;

namespace ZIPCodePH.DataContext.Data;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }

    public DbSet<ZipCode>? ZipCodes { get; set; }
    public DbSet<Area>? Areas { get; set; }
    public DbSet<Group>? Groups { get; set; }

    public DbSet<Trivia>? Trivia { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        // builder.Entity<GroupView>()
        //     .HasMany(e => e.Areas)
        //     .WithOne(e => e.GroupView)
        //     .HasForeignKey(e => e.GroupId)
        //     .HasPrincipalKey(e => e.Id);
        //
        // builder.Entity<Area>()
        //     .HasOne(e => e.Area)
        //     .HasForeignKey(e => e.AreaId)
        //     .HasPrincipalKey(e => e.Id);

        builder.Entity<ZipCode>()
            .Ignore(t => t.Code)
            .Ignore(t => t.Town)
            .Ignore(t => t.Area);
        
        base.OnModelCreating(builder);
    }
}