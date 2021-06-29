using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMulticom.Domain.Models;
using TMulticom.Test.FakeRepositories;

namespace TMulticom.Test.RepositoryTests
{
    

    [TestClass]
    public class JogoRepositoryTests
    {
        private JogoRepositoryFake _repository;
        private Jogo _jogo;

        public JogoRepositoryTests()
        {
            _repository = new JogoRepositoryFake();
        }

        [TestMethod]
        [DataRow("Teste")]
        public void Inserir_Jogo_Sucesso(string nome)
        {
            _jogo = new Jogo(nome);
            _repository.Adicionar(_jogo);
            var jogos = _repository.ObterTodos();
            Assert.IsTrue(jogos.Count() > 0);
        }

        [TestMethod]
        public void Excluir_Jogo_Sucesso()
        {
            Inserir_Jogo_Sucesso("teste");
            var Jogo = _repository.ObterTodos().FirstOrDefault();
            _repository.Remover(Jogo);
            var Jogos = _repository.ObterTodos();
            Assert.IsTrue(Jogos.Count() == 0);
        }

        [TestMethod]
        public void Editar_Jogo_Sucesso()
        {
            var nome = "teste";
            Inserir_Jogo_Sucesso(nome);
            var Jogo = _repository.ObterTodos().FirstOrDefault();
            Jogo.DefinirNome("teste 2");
            _repository.Atualizar(Jogo);
            var Jogo2 = _repository.ObterTodos().FirstOrDefault();
            Assert.IsTrue(Jogo2.Nome != nome);
        }
    }

    
}
