using ExMVC_01.Repository.Entities;
using System.ComponentModel.DataAnnotations;
namespace ExMVC_01.Presentation.Models
{
    public class ClienteConsultaViewModel
    {
        [Required(ErrorMessage = "Por favor, informe o nome desejado. ")]
        public string Nome { get; set; }

        #region Listagem de Clientes

        public List<Cliente>? Clientes { get; set; }

        #endregion
    }
}
