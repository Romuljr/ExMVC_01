using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.ComponentModel.DataAnnotations;
namespace ExMVC_01.Presentation.Models
{
    public class ClienteCadastroViewModel
    {
        [MinLength(6, ErrorMessage = "Por favor, informe no mínimo {1} caracteres. ")]
        [MaxLength(150, ErrorMessage = "Por favor, informe no máximo {1} caracteres. ")]
        [Required(ErrorMessage = "Por favor, informe o nome do cliente. ")]
        public string Nome { get; set; }

        [EmailAddress(ErrorMessage = "Por favor, informe um endereço de email válido.")]
        [Required(ErrorMessage = "Por favor, informe o email do cliente.")]
        public string Email { get; set; }

        [RegularExpression("^[0-9]{11}$", ErrorMessage = "Por favor, informe o CPF somente com números. ")]
        [Required(ErrorMessage = "Por favor, informe o CPF do cliente.")] 
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Por favor, informe a data de nascimento do cliente.")]
        public string DataNascimento { get; set; }

        [Required(ErrorMessage = "Por favor, informe o sexo do cliente.")]
        public string Sexo { get; set; }
    }
}
