using Dapper;
using Dapper.Contrib.Extensions;
using SGA.Application.Core;
using SGA.Application.Domain.Queries;
using SGA.Domain.Entities.Models;
using SGA.Infra.Dapper.Core;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SGA.Infra.Dapper.Queries
{
    public class PetQuery : BaseQuery<Pet>, IPetQuery
    {

        public PetQuery(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }

        public IEnumerable<TypePet> GetTypePets()
        {
            IEnumerable<TypePet> entities;

            using (var connection = new SqlConnection(_connectionFactory.GetConnection()))
            {
                entities = connection.GetAll<TypePet>();
            }

            return entities;
        }

        public IEnumerable<Pet> GetPetsNotAdopted()
        {
            var sql = string.Empty;

            sql += " SELECT[cd_animal] as Id";
            sql += " ,[nm_animal] as Naem";
            sql += " ,[dc_animal] as Description";
            sql += " ,[animal].[cd_tipo_animal] as TypePetId";
            sql += " ,t.cd_tipo_animal as split";
            sql += " ,t.[dc_tipo_animal] as Description";
            sql += " FROM[SGA].[dbo].[animal]";
            sql += " INNER JOIN [dbo].[tipo_animal] as t on  t.cd_tipo_animal = [animal].[cd_tipo_animal]";
            sql += " WHERE NOT EXISTS(select cd_animal from adocao)";

            using (var connection = new SqlConnection(_connectionFactory.GetConnection()))
            {
                var pets = connection.Query<Pet, TypePet, Pet>(sql, (p, t) =>
                {
                    p.SetTypePet(t);

                    return p;

                }, splitOn: "split");
            }

            return null;
        }
    }
}
