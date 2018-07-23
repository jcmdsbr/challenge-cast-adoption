using System;
using System.Data.Common;

namespace SGA.Application.Core
{
    public interface IConnectionFactory : IDisposable
    {
        DbConnection GetConnection();
    }
}