using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMulticom.Domain.Models;

namespace TMulticom.Domain.Data
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        void Adicionar(TEntity entity);
        TEntity ObterPorId(Guid id);
        IEnumerable<TEntity> ObterTodos();
        void Atualizar(TEntity entity);
        void Remover(TEntity entity);
        void RemoverPorId(Guid id);
        void Commit();


    }
}
