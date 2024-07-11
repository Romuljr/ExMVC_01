using ExMVC_01.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExMVC_01.Repository.Contracts
{
    public interface IClienteRepository : IBaseRepository<Cliente>
    {
        Cliente ObterPorCpf(string cpf);
        Cliente ObterPorEmail(string email);

        List<Cliente> ConsultarPorNome(string nome);
        //List<Cliente> ConsultarPorSexo(string sexo);

    }
}
