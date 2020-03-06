using System;
using System.Collections.Generic;
using System.Text;

namespace AE.Domain.Abstract
{
    public abstract class AuditableEntity: BaseEntity
    {
        public DateTime CreatedOn {get; set; }
        public int CreatedBy { get; set; }
        public DateTime ModifiedOn {get; set; }
        public int ModifiedBy { get; set; }

    }
}
