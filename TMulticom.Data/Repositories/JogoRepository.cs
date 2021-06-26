using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMulticom.Domain.Data;
using TMulticom.Domain.Models;

namespace TMulticom.Data.Repositories
{
    public class JogoRepository : BaseRepository<Jogo>, IJogoRepository
    {
        private readonly ApplicationDbContext _context;
        public JogoRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Jogo> ObterJogosDisponiveis()
        {
            return _context.Jogos.Where(x => x.AmigoId == null);
        }

        public IEnumerable<Jogo> ObterJogosEmprestados()
        {
            return _context.Jogos.Where(x => x.AmigoId != null);
        }
    }
}
