using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMulticom.Domain.Models;

namespace TMulticom.Data.Repositories
{
    public class JogoRepository : BaseRepository<Jogo>
    {
        public JogoRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
