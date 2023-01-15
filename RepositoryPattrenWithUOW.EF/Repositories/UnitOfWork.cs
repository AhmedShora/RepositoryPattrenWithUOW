using RepositoryPattrenWithUOW.Core;
using RepositoryPattrenWithUOW.Core.Interfaces;
using RepositoryPattrenWithUOW.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattrenWithUOW.EF.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IBooksRepository Books { get; private set; }
        public IBaseRepository<Author> Authors { get; private set; }
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Books = new BooksRepository(_context);
            Authors = new BaseRepository<Author>(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
