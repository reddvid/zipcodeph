using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZIPCodePH.DataContext.Entities;

public class Area
{
    public int Id { get; set; }
    public string Name { get; set; }

    public int GroupId { get; set; }
    public Group Group { get; set; }
    
}