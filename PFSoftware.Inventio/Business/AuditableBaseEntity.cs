using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PFSoftware.Business
{
    public class AuditableBaseEntity : BaseEntity, IAuditableObject
    {
        public AuditableBaseEntity() { }

        [ScaffoldColumn(false)]
        public DateTime CreateDate { get; set; }
        [ScaffoldColumn(false)]
        public string CreateUserId { get; set; }
        [ScaffoldColumn(false)]
        public DateTime? ModifyDate { get; set; }
        [ScaffoldColumn(false)]
        public string ModifyUserId { get; set; }
        [ScaffoldColumn(false)]
        public DateTime? DeleteDate { get; set; }
        [ScaffoldColumn(false)]
        public string DeleteUserId { get; set; }
    }
}
