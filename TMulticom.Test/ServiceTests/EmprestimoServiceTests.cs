using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMulticom.Domain.Models;
using TMulticom.Domain.Services;
using TMulticom.Test.FakeRepositories;

namespace TMulticom.Test.ServiceTests
{
    [TestClass]
    public class EmprestimoServiceTests
    {
        private readonly JogoRepositoryFake _jogoRepository;
        private readonly AmigoRepositoryFake _amigoRepository;

        public EmprestimoServiceTests()
        {
            _jogoRepository = new JogoRepositoryFake();
            _amigoRepository = new AmigoRepositoryFake();
        }

        [TestMethod]
        public void Devolver_Jogo_Sucesso()
        {
            var jogo = new Jogo("Jogo 1");
            _jogoRepository.Adicionar(jogo);

            var amigo = new Amigo("Amigo 1");
            _amigoRepository.Adicionar(amigo);

            jogo.InformarEmprestimo(amigo.Id);

            Assert.IsTrue(jogo.DataEmprestimo != null && jogo.AmigoId != null);

            jogo.RemoverEmprestimo();

            Assert.IsTrue(jogo.DataEmprestimo == null && jogo.AmigoId == null);
        }

        [TestMethod]
        public void Emprestar_Jogo_Sucesso()
        {
            var jogo = new Jogo("Jogo 1");
            _jogoRepository.Adicionar(jogo);

            var amigo = new Amigo("Amigo 1");
            _amigoRepository.Adicionar(amigo);

            jogo.InformarEmprestimo(amigo.Id);

            var jogoEmprestado = _jogoRepository.ObterPorId(jogo.Id);

            Assert.IsTrue(jogoEmprestado.AmigoId != null && jogoEmprestado.DataEmprestimo != null);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Jogo já emprestado.")]
        public void Emprestar_Jogo_Ja_Emprestado_Falha()
        {
            var jogo = new Jogo("Jogo 1");
            _jogoRepository.Adicionar(jogo);

            var amigo = new Amigo("Amigo 1");
            _amigoRepository.Adicionar(amigo);

            jogo.InformarEmprestimo(amigo.Id);

            Assert.IsTrue(jogo.DataEmprestimo != null && jogo.AmigoId != null);

            jogo.InformarEmprestimo(amigo.Id);
        }
    }
}
