using System;
using System.Collections.Generic;
using System.Text;
using AE.Domain.Abstract;
using AE.Domain.Enums;

namespace AE.Domain.Entities
{
    public class User : AuditableEntity
    {
        public string Name { get; private set; }
        public ERole Role { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public EGender Gender { get; private set; }
        public string Bio { get; private set; }

        public Organization Organization { get; private set; }

        public User(string name, ERole role, Organization organization, DateTime dateOfBirth, EGender gender, string bio)
        {
            Name = name;
            Role = role;
            Organization = organization;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Bio = bio;
        }
    }
}
