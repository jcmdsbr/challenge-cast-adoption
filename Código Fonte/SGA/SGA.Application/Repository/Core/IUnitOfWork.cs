using System;
using System.Collections.Generic;
using System.Text;
using SGA.Infra.CrossCutting.Response;

namespace SGA.Application.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        CommandResponse Commit();
    }
}
