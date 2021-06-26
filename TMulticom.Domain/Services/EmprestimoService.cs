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
        private readonly IBaseRepository<Jogo> _jogoRepository;
        private readonly IAmigoRepository _amigoRepository;

        public EmprestimoService(IBaseRepository<Jogo> jogoRepository, IAmigoRepository amigoRepository)
        {
            _jogoRepository = jogoRepository;
            _amigoRepository = amigoRepository;
        }

        public void EmprestarJogo(Guid jogoId, Guid amigoId)
        {

            var amigo = _amigoRepository.ObterPorId(amigoId);
            var jogo = _jogoRepository.ObterPorId(jogoId);

            //Validações


            jogo.AmigoId = amigoId;
            jogo.DataEmprestimo = DateTime.Now;

            _jogoRepository.Commit();

        }

        
    }
}
