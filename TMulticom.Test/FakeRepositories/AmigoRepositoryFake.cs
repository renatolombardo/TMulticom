using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMulticom.Domain.Data;
using TMulticom.Domain.Models;

namespace TMulticom.Test.FakeRepositories
{
    public class AmigoRepositoryFake : IAmigoRepository
    {
        private List<Amigo> _bd = new List<Amigo>();

        public AmigoRepositoryFake()
        {
            
        }

        public void Adicionar(Amigo entity)
        {
            _bd.Add(entity);
        }

        public void Atualizar(Amigo entity)
        {
            var item = _bd.FirstOrDefault(x => x.Id == entity.Id);
            item = entity;
        }

        public Amigo ObterPorId(Guid id)
        {
            return _bd.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Amigo> ObterTodosPorUserId(Guid userId)
        {
            return _bd;
        }

        public void Remover(Amigo entity)
        {
            _bd.Remove(entity);
        }

        public void RemoverPorId(Guid id)
        {
            var item = _bd.FirstOrDefault(x => x.Id == id);
            _bd.Remove(item);
        }

        public void Salvar()
        {
        }
    }
}
