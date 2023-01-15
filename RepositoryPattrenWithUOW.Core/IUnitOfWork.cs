using RepositoryPattrenWithUOW.Core.Interfaces;
using RepositoryPattrenWithUOW.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattrenWithUOW.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<Author> Authors { get; }
        IBooksRepository Books { get; }
        int Complete();
    }
}
