using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMulticom.Domain.Data;
using TMulticom.Domain.Models;

namespace TMulticom.Test.FakeRepositories
{
    public class JogoRepositoryFake : IJogoRepository
    {
        private List<Jogo> _bd;

        public JogoRepositoryFake()
        {
            _bd = new List<Jogo>();
        }

        public void Adicionar(Jogo entity)
        {
            _bd.Add(entity);
        }

        public void Atualizar(Jogo entity)
        {
            var item = _bd.FirstOrDefault(x => x.Id == entity.Id);
            item = entity;
        }

        public IEnumerable<Jogo> ObterJogosDisponiveis()
        {
            return _bd.Where(x => x.DataEmprestimo == null && x.AmigoId == null);
        }

        public IEnumerable<Jogo> ObterJogosEmprestados()
        {
            return _bd.Where(x => x.DataEmprestimo != null || x.AmigoId != null);
        }

        public Jogo ObterPorId(Guid id)
        {
            return _bd.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Jogo> ObterTodos()
        {
            return _bd;
        }

        public void Remover(Jogo entity)
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
