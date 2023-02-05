using System.ComponentModel.DataAnnotations;

namespace Data.DTOs;
public class LoginUserDTO
{
    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
    [Required]
    [StringLength(15, MinimumLength = 10, ErrorMessage = "your password is limited to {2} to {1} characters")]
    public string Password { get; set; }
}
public class UserDTO : LoginUserDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    [DataType(DataType.PhoneNumber)]
    public string PhoneNumber { get; set; }


}