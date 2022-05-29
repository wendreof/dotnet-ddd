using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.Login
{
    public class LoginDto
    {
        [Required(ErrorMessage = "E-mail eh obrigatorio")]
        [EmailAddress(ErrorMessage = "E-mail invalido")]
        [StringLength(100, ErrorMessage = "E-mail deve ter no maximo 100 caracteres")]
        public string Email { get; set; }
    }
}