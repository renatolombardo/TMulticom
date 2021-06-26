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
    public class AmigoRepository : BaseRepository<Amigo>, IAmigoRepository
    {
        private readonly ApplicationDbContext _context;
        public AmigoRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public override IEnumerable<Amigo> ObterTodos()
        {
            var y = _context.Amigos.Include(x => x.Jogos);
            return y;
        }

        public override Amigo ObterPorId(Guid id)
        {
            var y = _context.Amigos.Include(x => x.Jogos).
                FirstOrDefault(x => x.Id == id);
            return y;
        }

    }
}
