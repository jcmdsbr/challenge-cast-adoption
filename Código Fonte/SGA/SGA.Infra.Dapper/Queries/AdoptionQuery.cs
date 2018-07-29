using Dapper;
using SGA.Application.Core;
using SGA.Application.Domain.Dtos;
using SGA.Application.Domain.Queries;
using SGA.Domain.Entities.Models;
using SGA.Infra.Dapper.Core;
using SGA.Infra.Dapper.Maps;
using SGA.Infra.Dapper.Procedures;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SGA.Infra.Dapper.Queries
{
    public class AdoptionQuery : Query<Adoption>, IAdoptionQuery
    {
        public AdoptionQuery(IConnectionFactory connection) : base(connection)
        {
        }

        public IEnumerable<AdoptionDto> GetReponsablesAndTheirAdoptions()
        {
            IEnumerable<AdoptionDto> adoptions;

            using (var connection = ConnectionFactory.GetConnection())
            {
                adoptions = connection.Query(
                    AdoptionProcedure.GetReponsablesAndTheirAdoptions,
                    AdoptionMap.AdoptionDto(),
                    splitOn: "split, splitCpf, splitEmail",
                    commandType: CommandType.StoredProcedure
                ).AsQueryable();
            }

            return adoptions;
        }

        public AdoptionDto FindReponsableAndTheirAdoptionsBy(Guid id)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@cd_responsavel", id);

            AdoptionDto adoptionDto;

            using (var connection = ConnectionFactory.GetConnection())
            {
                adoptionDto = connection.Query(
                    AdoptionProcedure.FindReponsableAndTheirAdoptionsById,
                    AdoptionMap.AdoptionDto(),
                    parameters,
                    splitOn: "split, splitCpf, splitEmail",
                    commandType: CommandType.StoredProcedure
                ).SingleOrDefault();
            }

            return adoptionDto;
        }
    }
}