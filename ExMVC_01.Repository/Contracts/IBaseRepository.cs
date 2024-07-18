using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExMVC_01.Repository.Contracts
{
    public interface IBaseRepository<TEntity>
    {
        void Inserir(TEntity obj);
        void Alterar(TEntity obj);
        void Excluir(TEntity obj);

        List<TEntity> Consultar();
        TEntity ObterPorId(Guid id);
    }
}
