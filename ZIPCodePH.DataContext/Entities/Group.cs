using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZIPCodePH.DataContext.Entities;

public class Group
{
    public int Id { get; set; }
    public string Name { get; set; }
    
}