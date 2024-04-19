using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZIPCodePH.DataContext.Entities;

public class ZipCode
{
    public int Id { get; set; }
    
    [MaxLength(4)]
    public ushort Code { get; set; }
    public string Town { get; set; }
    
    public int AreaId { get; set; }
    public Area Area { get; set; }
    
}