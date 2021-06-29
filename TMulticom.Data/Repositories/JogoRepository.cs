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

        public override IEnumerable<Jogo> ObterTodosPorUserId(Guid userId)
        {
            var ret = _context.Jogos
                .Where(x => x.UserId == userId)
                .Include(x => x.Amigo);
            var x = base.ObterTodosPorUserId(userId);

            return ret;
        }

        public IEnumerable<Jogo> ObterJogosDisponiveis(Guid userId)
        {
            return _context.Jogos.Where(x => x.AmigoId == null && x.UserId == userId);
        }

        public IEnumerable<Jogo> ObterJogosEmprestados(Guid userId)
        {
            var ret = _context.Jogos.Where(x => x.AmigoId != null && x.UserId == userId) 
                .Include(x => x.Amigo);
            return ret;
        }

    }
}
