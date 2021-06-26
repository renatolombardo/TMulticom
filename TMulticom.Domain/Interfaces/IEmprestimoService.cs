using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMulticom.Domain.Services
{
    public interface IEmprestimoService
    {
        void EmprestarJogo(Guid jogoId, Guid amigoId);
    }
}
