using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMulticom.Domain.Models;

namespace TMulticom.Domain.Data
{
    public interface IBaseRepository<T> where T : class
    {
        void Adicionar(T entity);
        T ObterPorId(Guid id);
        IEnumerable<T> ObterTodos();
        void Atualizar(T entity);
        void Remover(T entity);
        void RemoverPorId(Guid id);
        void Salvar();


    }
}
