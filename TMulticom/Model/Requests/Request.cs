using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TMulticom.Web.Model.Requests
{
    public abstract class Request
    {
        public Guid Id { get; set; }
    }
}
