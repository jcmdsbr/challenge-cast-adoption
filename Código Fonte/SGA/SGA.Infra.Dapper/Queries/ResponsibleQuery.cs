using SGA.Application.Core;
using SGA.Application.Domain.Queries;
using SGA.Domain.Entities.Models;
using SGA.Infra.Dapper.Core;

namespace SGA.Infra.Dapper.Queries
{
    public class ResponsibleQuery : BaseQuery<Responsible>, IResponsibleQuery
    {
        public ResponsibleQuery(IConnectionFactory connection) : base(connection)
        {
        }
    }
}