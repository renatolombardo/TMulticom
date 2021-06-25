using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMulticom.Domain.Models;

namespace TMulticom.Data.Repositories
{
    public class AmigoRepository : BaseRepository<Amigo>
    {
        public AmigoRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
