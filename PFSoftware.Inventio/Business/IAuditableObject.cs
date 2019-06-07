using System;
using System.Collections.Generic;
using System.Text;

namespace PFSoftware.Business
{
    public interface IAuditableObject
    {
        DateTime CreateDate { get; set; }
        string CreateUserId { get; set; }
        DateTime? ModifyDate { get; set; }
        string ModifyUserId { get; set; }
        DateTime? DeleteDate { get; set; }
        string DeleteUserId { get; set; }
    }
}
