using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMulticom.Domain.Data;
using TMulticom.Domain.Models;

namespace TMulticom.Domain.Services
{
    public class EmprestimoService : IEmprestimoService
    {
        private readonly IJogoRepository _jogoRepository;
        private readonly IAmigoRepository _amigoRepository;

        public EmprestimoService(IJogoRepository jogoRepository, IAmigoRepository amigoRepository)
        {
            _jogoRepository = jogoRepository;
            _amigoRepository = amigoRepository;
        }

        public void EmprestarJogo(Guid jogoId, Guid amigoId)
        {

            var amigo = _amigoRepository.ObterPorId(amigoId);
            var jogo = _jogoRepository.ObterPorId(jogoId);

            //Validações
            if (amigo == null)
                throw new Exception("Amigo não encontrado");

            if (jogo == null)
                throw new Exception("Jogo não encontrado");

            jogo.InformarEmprestimo(amigoId);

            _jogoRepository.Salvar();
        }

        public void DevolverJogo(Guid jogoId)
        {
            var jogo = _jogoRepository.ObterPorId(jogoId);

            //Validações
            if (jogo == null)
                throw new Exception("Jogo não encontrado");

            jogo.RemoverEmprestimo();

            _jogoRepository.Salvar();

        }

    }
}
