using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMulticom.Data;
using TMulticom.Data.Repositories;
using TMulticom.Domain.Models;
using TMulticom.Test.FakeRepositories;

namespace TMulticom.Test.RepositoryTests
{
    [TestClass]
    public class AmigoRepositoryTests
    {
        private AmigoRepositoryFake _repository = new AmigoRepositoryFake();
        private Amigo _amigo;

        [TestMethod]
        [DataRow("Teste")]
        public void Inserir_Amigo_Sucesso(string nome)
        {
            _amigo = new Amigo(nome);
            _repository.Adicionar(_amigo);
            var amigos = _repository.ObterTodosPorUserId(new Guid());
            Assert.IsTrue(amigos.Count() > 0);
        }

        [TestMethod]
        public void Excluir_Amigo_Sucesso()
        {
            var id = new Guid();
            _amigo = new Amigo("Teste");
            _repository.Adicionar(_amigo);
            var amigo = _repository.ObterTodosPorUserId(id).FirstOrDefault();
            _repository.Remover(amigo);
            var amigos = _repository.ObterTodosPorUserId(id);
            Assert.IsTrue(amigos.Count() == 0);
        }

        [TestMethod]
        public void Editar_Amigo_Sucesso()
        {
            var id = new Guid();
            var nome = "teste";
            _amigo = new Amigo(nome);
            _repository.Adicionar(_amigo);
            var amigo = _repository.ObterTodosPorUserId(id).FirstOrDefault();            
            amigo.DefinirNome("teste 2");           
            _repository.Atualizar(amigo);
            var amigo2 = _repository.ObterTodosPorUserId(id).FirstOrDefault();
            Assert.IsTrue(amigo2.Nome != nome);
        }
    }
}
