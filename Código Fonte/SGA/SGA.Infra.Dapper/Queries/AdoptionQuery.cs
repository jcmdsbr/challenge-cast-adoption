using Dapper;
using SGA.Application.Domain.Dtos;
using SGA.Application.Domain.Queries;
using SGA.Domain.Entities.Models;
using SGA.Infra.Dapper.Core;
using SGA.Infra.Dapper.Procedures;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace SGA.Infra.Dapper.Queries
{
    public class AdoptionQuery : BaseQuery<Adoption>, IAdoptionQuery
    {
        public AdoptionQuery(DbConnection connection) : base(connection)
        {
        }

        public IEnumerable<AdoptionDto> GetReponsablesAndTheirAdoptions()
        {
            IEnumerable<AdoptionDto> adoptions;

            using (var connection = _connection)
            {
                adoptions = connection.Query<AdoptionDto, Responsible, AdoptionDto>(
                    AdoptionProcedure.GetReponsablesAndTheirAdoptions,
                    (ad, res) =>
                      {
                          ad.Responsible = res;
                          return ad;
                      }, splitOn: "split");
            }

            return adoptions;
        }


        public AdoptionDto FindReponsableAndTheirAdoptionsBy(Guid id)
        {
            var sql = string.Format(AdoptionProcedure.FindReponsableAndTheirAdoptionsById, id);

            AdoptionDto adoptionDto;

            using (var connection = _connection)
            {
                adoptionDto = connection.Query<AdoptionDto, Responsible, AdoptionDto>(sql, (ad, res) =>
                {
                    ad.Responsible = res;
                    return ad;
                }, splitOn: "split").Single();
            }

            return adoptionDto;
        }
    }
}
