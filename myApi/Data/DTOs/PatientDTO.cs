using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Models;

namespace Data.DTOs;


public class CreatePatientDTO
{
    [Required]
    public DateTime Insertdate { get; set; } = DateTime.Now;
    public string Givenid { get; set; } = string.Empty;
    [Required]
    [DataType(DataType.PhoneNumber)]
    [StringLength(11, ErrorMessage = "The National id  length is 11 characters.")]
    [MinLength(11, ErrorMessage = "The National id length  is 11 characters.")]
    public string Nationalidnumber { get; set; } = string.Empty;
    [Required]

    [StringLength(maximumLength: 50, ErrorMessage = "The Firstname is too long")]
    public string Firstname { get; set; } = string.Empty;
    [Required]

    [StringLength(maximumLength: 50, ErrorMessage = "The Middlename is too long")]
    public string? Middlename { get; set; }
    [Required]

    [StringLength(maximumLength: 50, ErrorMessage = "The Lastname is too long")]
    public string Lastname { get; set; } = string.Empty;



}
public class UpdatePatientDTO : CreatePatientDTO
{

}

public class PatientDTO : CreatePatientDTO
{
    public int Id { get; set; }
    public ICollection<RadOrderDTO> Orders { get; set; }

}