using SGA.Infra.CrossCutting.Response;
using System;

namespace SGA.Application.Core
{
    public interface IUnitOfWork : IDisposable
    {
        CommandResponse Commit();
    }
}