using System;
using SGA.Infra.CrossCutting.Response;

namespace SGA.Application.Repository.Core
{
    public interface IUnitOfWork : IDisposable
    {
        CommandResponse Commit();
    }
}