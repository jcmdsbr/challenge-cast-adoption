using SGA.Application.Domain.Queries;
using SGA.Domain.Entities.Models;
using SGA.Infra.Dapper.Core;
using System.Data.Common;

namespace SGA.Infra.Dapper.Queries
{
    public class ResponsibleQuery : BaseQuery<Responsible>, IResponsibleQuery
    {
        public ResponsibleQuery(DbConnection connection) : base(connection)
        {
        }
    }
}
