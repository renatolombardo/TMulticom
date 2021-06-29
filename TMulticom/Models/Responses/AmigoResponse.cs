using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TMulticom.Web.Model.Responses
{
    public class AmigoResponse : Response
    {
        public string Nome { get; set; }

        public List<JogoResponse> Jogos { get; set; }
    }
}
