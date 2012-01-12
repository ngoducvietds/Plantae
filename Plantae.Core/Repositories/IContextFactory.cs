using System;
using System.Data.Linq;

namespace Plantae.Core.Repositories
{
    public interface IContextFactory : IDisposable
    {
        DataContext Get();
    }
}
