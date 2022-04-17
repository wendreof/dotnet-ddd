using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.User
{
  public class UserDto
  {
    [DefaultValue("wendreo@dotnet.com")]
    [Required(ErrorMessage = "Name eh obrigatorio")]
    [EmailAddress(ErrorMessage = "Name invalido")]
    [StringLength(60, ErrorMessage = "Name deve ter no maximo {1} caracteres")]
    public string Name { get; set; }

    [DefaultValue("Wendreo BackEnd Developer")]
    [Required(ErrorMessage = "E-mail eh obrigatorio")]
    [EmailAddress(ErrorMessage = "E-mail invalido")]
    [StringLength(100, ErrorMessage = "E-mail deve ter no maximo {1} caracteres")]
    public string Email { get; set; }
  }
}