using Microsoft.EntityFrameworkCore.ChangeTracking;
using ZIPCodePH.DataContext.Entities;

namespace ZIPCodePH.Tests.Unit.Fakes;

public class ApplicationContextFakeBuilder : IDisposable
{
    private readonly ApplicationContextFake _context = new();

    private EntityEntry<Group> _ncrGroup;
    private EntityEntry<Group> _luzonGroup;
    private EntityEntry<Group> _visayasGroup;
    private EntityEntry<Area> _manilaArea;
    private EntityEntry<Area> _pangasinanArea;
    private EntityEntry<Area> _batangasArea;
    private EntityEntry<Area> _cebuArea;

    public ApplicationContextFakeBuilder WithAllFourGroups()
    {
        _context.Add(new Group { Name = "NCR" });
        _context.Add(new Group { Name = "Luzon" });
        _context.Add(new Group { Name = "Visayas" });
        _context.Add(new Group { Name = "Mindanao" });
        return this;
    }
    
    public ApplicationContextFakeBuilder WithOneZipCode()
    {
        _ncrGroup = _context.Add(new Group { Name = "NCR" });
        _manilaArea = _context.Add(new Area { Name = "Manila", Group = _ncrGroup.Entity });
        _context.Add(new ZipCode { Code = 1128, Area = _manilaArea.Entity, Town = "Culiat" });
        return this;
    }

    public ApplicationContextFakeBuilder WithFiveZipCodes()
    {
        _ncrGroup = _context.Add(new Group { Name = "NCR" });
        _luzonGroup = _context.Add(new Group { Name = "Luzon" });
        _visayasGroup = _context.Add(new Group { Name = "Visayas" });

        _manilaArea = _context.Add(new Area { Name = "Manila", Group = _ncrGroup.Entity });
        _pangasinanArea = _context.Add(new Area { Name = "Pangasinan", Group = _luzonGroup.Entity });
        _batangasArea = _context.Add(new Area { Name = "Batangas", Group = _luzonGroup.Entity });
        _cebuArea = _context.Add(new Area { Name = "Cebu", Group = _visayasGroup.Entity });

        _context.Add(new ZipCode { Code = 1128, Area = _manilaArea.Entity, Town = "Culiat" });
        _context.Add(new ZipCode { Code = 1126, Area = _manilaArea.Entity, Town = "Batasan Hills" });
        _context.Add(new ZipCode { Code = 2418, Area = _pangasinanArea.Entity, Town = "Calasiao" });
        _context.Add(new ZipCode { Code = 4225, Area = _batangasArea.Entity, Town = "Rosario" });
        _context.Add(new ZipCode { Code = 6000, Area = _cebuArea.Entity, Town = "Cebu City" });

        return this;
    }

    public ApplicationContextFakeBuilder WithContainingNames()
    {
        var _caviteArea = _context.Add(new Area { Name = "Cavite", Group = _luzonGroup.Entity });
        var _laUnionArea = _context.Add(new Area { Name = "La Union", Group = _luzonGroup.Entity });

        _context.Add(new ZipCode { Code = 4106, Area = _caviteArea.Entity, Town = "Rosario" });
        _context.Add(new ZipCode { Code = 2506, Area = _laUnionArea.Entity, Town = "Rosario" });

        return this;
    }

    public ApplicationContextFake Build()
    {
        _context.SaveChangesAsync();
        return _context;
    }

    public void Dispose()
    {
        _context.Database.EnsureDeleted();
        _context.Dispose();
    }
}