using Dapper.Contrib.Extensions;
using SGA.Domain.Entities.Core;
using SGA.Domain.Entities.ValueObjects;
using System;

namespace SGA.Domain.Entities.Models
{
    [Table("responsavel")]
    public class Responsible : Entity
    {
        public Responsible(Guid id, string name, Cpf cpf, Email email)
        {
            Id = id;
            Name = name;
            Cpf = cpf;
            Email = email;
        }

        public Responsible(Guid id, string name, string cpf, string email)
        {
            Id = id;
            Name = name;
            Cpf = new Cpf(cpf);
            Email = new Email(email);
        }

        public Responsible() { }

        public string Name { get; private set; }

        public Cpf Cpf { get; private set; }

        public Email Email { get; private set; }

    }
}
