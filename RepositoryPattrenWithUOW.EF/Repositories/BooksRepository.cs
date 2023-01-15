using RepositoryPattrenWithUOW.Core.Interfaces;
using RepositoryPattrenWithUOW.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattrenWithUOW.EF.Repositories
{
    public class BooksRepository : BaseRepository<Book>, IBooksRepository
    {
        private readonly AppDbContext _context;

        public BooksRepository(AppDbContext context) : base(context)
        {
        }

        public IEnumerable<Book> GetSpecialBooks()
        {
            return _context.Books.ToList();
        }
    }
}
