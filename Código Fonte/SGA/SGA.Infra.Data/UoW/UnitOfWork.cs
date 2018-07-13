using SGA.Application.Core;
using SGA.Infra.CrossCutting.Response;
using SGA.Infra.Repository.Context;

namespace SGA.Infra.Repository.UoW
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly SgaContext _context;

        public UnitOfWork(SgaContext context)
        {
            _context = context;
        }

        public CommandResponse Commit()
        {
            var rowsAffected = _context.SaveChanges();

            return new CommandResponse(rowsAffected > 0);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}