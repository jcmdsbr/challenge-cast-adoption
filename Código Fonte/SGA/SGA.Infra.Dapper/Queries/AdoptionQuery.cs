using Dapper;
using SGA.Application.Core;
using SGA.Application.Domain.Dtos;
using SGA.Application.Domain.Queries;
using SGA.Domain.Entities.Models;
using SGA.Infra.Dapper.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace SGA.Infra.Dapper.Queries
{
    public class AdoptionQuery : BaseQuery<Adoption>, IAdoptionQuery
    {
        public AdoptionQuery(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }

        public IEnumerable<AdoptionDto> GetReponsablesAndTheirAdoptions()
        {
            var sql = string.Empty;
            sql += "SELECT(select COUNT(cd_responsavel) from adocao where responsavel.cd_responsavel = adocao.cd_responsavel) as AdoptedPets";
            sql += ",cd_responsavel as Id";
            sql += ",nm_responsavel as Name";
            sql += ",cpf_responsavel as Cpf";
            sql += ",email_responsavel as Email";
            sql += "FROM responsavel";

            using (var connection = new SqlConnection(_connectionFactory.GetConnection()))
            {
                var adoptions = connection.Query<AdoptionDto, Responsible, AdoptionDto>(sql, (ad, res) =>
                       {
                           ad.Responsible = res;
                           return ad;
                       }, splitOn: "Id");
            }

            return null;
        }


        public AdoptionDto FindReponsableAndTheirAdoptionsBy(Guid id)
        {
            var sql = string.Empty;
            sql += "SELECT(select COUNT(cd_responsavel) from adocao where responsavel.cd_responsavel = adocao.cd_responsavel) as AdoptedPets";
            sql += ",cd_responsavel as Id";
            sql += ",nm_responsavel as Name";
            sql += ",cpf_responsavel as Cpf";
            sql += ",email_responsavel as Email";
            sql += "FROM responsavel";
            sql += $"WHERE  responsavel.cd_responsavel = {id}";

            using (var connection = new SqlConnection(_connectionFactory.GetConnection()))
            {
                var adoptions = connection.Query<AdoptionDto, Responsible, AdoptionDto>(sql, (ad, res) =>
                {
                    ad.Responsible = res;
                    return ad;
                }, splitOn: "Id").Single();
            }

            return null;
        }
    }
}
