using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Models;

namespace Data.DTOs;

public class CreateRadOrderDTO
{
    [Required]
    public DateTime Insertdate { get; set; } = DateTime.Now;
    [Required]
    public int PatientId { get; set; }
}
public class RadOrderDTO : CreateRadOrderDTO
{
    public int Id { get; set; }
    public PatientDTO patient { get; set; }
}
