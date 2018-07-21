using Dapper;
using SGA.Application.Domain.Queries;
using SGA.Domain.Entities.Models;
using SGA.Infra.Dapper.Core;
using SGA.Infra.Dapper.Procedures;
using System.Collections.Generic;
using System.Data.Common;

namespace SGA.Infra.Dapper.Queries
{
    public class PetQuery : BaseQuery<Pet>, IPetQuery
    {

        public PetQuery(DbConnection connection) : base(connection)
        {
        }

        public IEnumerable<TypePet> GetTypePets()
        {
            IEnumerable<TypePet> entities;

            using (var connection = _connection)
            {
                entities = connection.Query<TypePet>(PetProcedure.GetTypePets);
            }

            return entities;
        }

        public IEnumerable<Pet> GetPetsNotAdopted()
        {
            IEnumerable<Pet> pets;

            using (var connection = _connection)
            {
                pets = connection.Query<Pet, TypePet, Pet>(
                    PetProcedure.GetPetsNotAdopted,
                    (p, t) =>
                           {
                               p.SetTypePet(t);
                               return p;
                           }, splitOn: "split");
            }

            return pets;
        }
    }
}
