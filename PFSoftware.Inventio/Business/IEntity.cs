using System;
using System.Collections.Generic;
using System.Text;

namespace PFSoftware.Business
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
