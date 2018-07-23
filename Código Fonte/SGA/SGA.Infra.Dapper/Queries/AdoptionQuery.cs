using Dapper;
using SGA.Application.Core;
using SGA.Application.Domain.Dtos;
using SGA.Application.Domain.Queries;
using SGA.Domain.Entities.Models;
using SGA.Domain.Entities.ValueObjects;
using SGA.Infra.Dapper.Core;
using SGA.Infra.Dapper.Procedures;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SGA.Infra.Dapper.Queries
{
    public class AdoptionQuery : BaseQuery<Adoption>, IAdoptionQuery
    {
        public AdoptionQuery(IConnectionFactory connection) : base(connection)
        {
        }

        public IEnumerable<AdoptionDto> GetReponsablesAndTheirAdoptions()
        {
            IEnumerable<AdoptionDto> adoptions;

            using (var connection = ConnectionFactory.GetConnection())
            {
                adoptions = connection.Query<AdoptionDto, Responsible, Cpf, Email, AdoptionDto>(
                    AdoptionProcedure.GetReponsablesAndTheirAdoptions,
                    (ad, res, cpf, email) =>
                    {
                        res.SetCpf(cpf);
                        res.SetEmail(email);
                        ad.Responsible = res;
                        return ad;
                    }, splitOn: "split, splitCpf, splitEmail");
            }

            return adoptions;
        }

        public AdoptionDto FindReponsableAndTheirAdoptionsBy(Guid id)
        {
            var sql = string.Format(AdoptionProcedure.FindReponsableAndTheirAdoptionsById, id);

            AdoptionDto adoptionDto;

            using (var connection = ConnectionFactory.GetConnection())
            {
                adoptionDto = connection.Query<AdoptionDto, Responsible, Cpf, Email, AdoptionDto>(
                    sql,
                    (ad, res, cpf, email) =>
                    {
                        res.SetCpf(cpf);
                        res.SetEmail(email);
                        ad.Responsible = res;
                        return ad;
                    }, splitOn: "split, splitCpf, splitEmail").SingleOrDefault();
            }

            return adoptionDto;
        }
    }
}