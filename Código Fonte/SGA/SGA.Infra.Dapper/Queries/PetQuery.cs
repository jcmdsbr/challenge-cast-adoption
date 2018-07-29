using Dapper;
using SGA.Application.Core;
using SGA.Application.Domain.Queries;
using SGA.Domain.Entities.Models;
using SGA.Infra.Dapper.Core;
using SGA.Infra.Dapper.Maps;
using SGA.Infra.Dapper.Procedures;
using System.Collections.Generic;
using System.Data;

namespace SGA.Infra.Dapper.Queries
{
    public class PetQuery : Query<Pet>, IPetQuery
    {
        public PetQuery(IConnectionFactory connection) : base(connection)
        {
        }

        public IEnumerable<TypePet> GetTypePets()
        {
            IEnumerable<TypePet> typesPets;

            using (var connection = ConnectionFactory.GetConnection())
            {
                typesPets = connection.Query<TypePet>(
                    PetProcedure.GetTypePets,
                    commandType: CommandType.StoredProcedure);
            }

            return typesPets;
        }

        public IEnumerable<Pet> GetPetsNotAdopted()
        {
            IEnumerable<Pet> pets;

            using (var connection = ConnectionFactory.GetConnection())
            {
                pets = connection.Query(
                    PetProcedure.GetPetsNotAdopted,
                    PetMap.FullPet(),
                    splitOn: "split",
                    commandType: CommandType.StoredProcedure);
            }

            return pets;
        }
    }
}