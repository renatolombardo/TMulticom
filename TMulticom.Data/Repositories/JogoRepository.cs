using Microsoft.EntityFrameworkCore;
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

        public override IEnumerable<Jogo> ObterTodos()
        {
            var ret = _context.Jogos.Include(x => x.Amigo);
            return ret;
        }

        public override Jogo ObterPorId(Guid id)
        {
            var ret = _context.Jogos
                .Include(x => x.Amigo)
                .FirstOrDefault(x => x.Id == id);
            return ret;
        }

        public IEnumerable<Jogo> ObterJogosDisponiveis()
        {
            return _context.Jogos.Where(x => x.AmigoId == null);
        }

        public IEnumerable<Jogo> ObterJogosEmprestados()
        {
            var ret = _context.Jogos.Where(x => x.AmigoId != null)
                .Include(x => x.Amigo);
            return ret;
        }
    }
}
