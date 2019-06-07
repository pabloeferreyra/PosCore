using System;
using System.Collections.Generic;
using System.Text;

namespace PFSoftware.Business
{
    public abstract class AuditableEntity<T> : AuditableBaseEntity, IEntity<T>
    {
        protected AuditableEntity() { }

        public virtual T Id { get; set; }
    }
}
