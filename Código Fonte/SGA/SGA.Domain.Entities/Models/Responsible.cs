using System;
using System.Collections.Generic;
using SGA.Domain.Entities.Core;
using SGA.Domain.Entities.ValueObjects;

namespace SGA.Domain.Entities.Models
{
    public class Responsible : Entity
    {
        public Responsible(Guid id, string name, Cpf cpf, Email email)
        {
            Id = id;
            Name = name;
            Cpf = cpf;
            Email = email;
        }

        protected Responsible()  { }

        public string Name { get; private set; }
        public Cpf Cpf { get; private set; }

        public Email Email { get; private set; }

    }
}
