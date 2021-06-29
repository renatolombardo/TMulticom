using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMulticom.Domain.Models
{
    public abstract class Entity : IEntity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        public void DefinirUserId(Guid userId)
        {
            UserId = userId;
        }
    }
}
