using System;
using System.Collections.Generic;
using System.Text;
using AE.Domain.Abstract;
using AE.Domain.Enums;

namespace AE.Domain.Entities
{
    public class Organization : AuditableEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public EOraganizationDomain Domain { get; private set; }
    }
}
