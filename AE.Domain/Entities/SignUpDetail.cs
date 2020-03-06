using System;
using System.Collections.Generic;
using System.Text;
using AE.Domain.Abstract;
using AE.Domain.Enums;

namespace AE.Domain.Entities
{
    public class SignUpDetail : BaseEntity
    {
        public string Name { get; private set; }
        public string Url { get; private set; }
        public string EnterpriseToken { get; private set; }
        public string EnterpriseId { get; private set; }
        public EStatus Status { get; private set; }

        public int OrganizationId { get; private set; }
        public Organization Organization { get; private set; }

        public SignUpDetail(string name, string url, string enterpriseToken, EStatus status, Organization organization)
        {
            Name = name;
            Url = url;
            EnterpriseToken = enterpriseToken;
            Status = status;
            Organization = organization;
        }

        public void addEnterprise(string Id)
        {
            EnterpriseId = Id;
        }
    }
}
