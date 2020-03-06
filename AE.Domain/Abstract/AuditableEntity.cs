using System;
using System.Collections.Generic;
using System.Text;

namespace AE.Domain.Abstract
{
    public abstract class AuditableEntity: BaseEntity
    {
        public DateTime CreatedOn {get; set; }
        public long CreatedBy { get; set; }
        public DateTime ModifiedOn {get; set; }
        public long ModifiedBy { get; set; }

    }
}
