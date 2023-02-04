using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Entities;

namespace Data.Models;

public class RadOrder
{
    public int Id { get; set; }
    public DateTime Insertdate { get; set; } = DateTime.Now;
    [ForeignKey(nameof(Patient))]
    public int PatientId { get; set; }

    public Patient patient { get; set; }



}