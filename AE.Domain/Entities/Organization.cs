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

        private readonly List<SignUpDetail> _signUpDetails = new List<SignUpDetail>();
        public IReadOnlyCollection<SignUpDetail> SignUpDetails => _signUpDetails.AsReadOnly();

        public Organization(string name, string description, EOraganizationDomain domain)
        {
            Name = name;
            Description = description;
            Domain = domain;
        }

        public void AddSignUpDetails(SignUpDetail signUpDetail)
        {
            this._signUpDetails.Add(signUpDetail);
        }

        public void RemoveSignUpDetails(SignUpDetail signUpDetail)
        {
            this._signUpDetails.Remove(signUpDetail);
        }
    }
}
