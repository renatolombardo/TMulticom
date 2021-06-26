using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TMulticom.Web.Model.Responses
{
    public class JogoResponse : Response
    {
        public string Nome { get; set; }
        public DateTime? DataEmprestimo { get; set; }
        public AmigoResponse Amigo { get; set; }
    }
}
