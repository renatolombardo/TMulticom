using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TMulticom.Web.Model.Requests
{
    public class EmprestarJogoRequest
    {
        public Guid JogoId { get; set; }
        public Guid AmigoId { get; set; }
    }
}
