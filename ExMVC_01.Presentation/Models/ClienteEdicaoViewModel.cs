using System.ComponentModel.DataAnnotations;

namespace ExMVC_01.Presentation.Models
{
    public class ClienteEdicaoViewModel
    {
        public Guid Id { get; set; }

        [MinLength(6, ErrorMessage = "Por favor, informe no mínimo {1} caracteres. ")]
        [MaxLength(150, ErrorMessage = "Por favor, informe no máximo {1} caracteres. ")]
        [Required(ErrorMessage = "Por favor, informe o nome do cliente. ")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe a data de nascimento do cliente. ")]
        public string DataNascimento { get; set; }

        [Required(ErrorMessage = "Por favor, informe o sexo do cliente. ")]
        public string Sexo { get; set; }
    }
}
