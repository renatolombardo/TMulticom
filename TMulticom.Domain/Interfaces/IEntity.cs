﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMulticom.Domain.Models
{
    public interface IEntity
    {
        Guid Id { get; set; }
        Guid UserId { get; set; }
    }
}
