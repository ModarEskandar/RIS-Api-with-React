using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models;

public class Patient
{
    public int Id { get; set; }
    public DateTime Insertdate { get; set; } = DateTime.Now;
    public string Givenid { get; set; } = string.Empty;
    public string Nationalidnumber { get; set; } = string.Empty;
    public string Firstname { get; set; } = string.Empty;
    public string? Middlename { get; set; }
    public string Lastname { get; set; } = string.Empty;
    [ForeignKey("PatientId")]
    public virtual ICollection<RadOrder> Orders { get; set; }

}
