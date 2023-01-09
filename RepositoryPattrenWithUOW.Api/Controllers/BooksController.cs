using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPattrenWithUOW.Core.Consts;
using RepositoryPattrenWithUOW.Core.Interfaces;
using RepositoryPattrenWithUOW.Core.Models;

namespace RepositoryPattrenWithUOW.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBaseRepository<Book> _booksRepo;

        public BooksController(IBaseRepository<Book> booksRepo)
        {
            _booksRepo = booksRepo;
        }
        [HttpGet]
        public IActionResult GetById()
        {
            var book = _booksRepo.GetById(1);
            return Ok(book);
        }

        [HttpGet("FindByName")]
        public IActionResult FindByName()
        {
            var book = _booksRepo.FilterBy(aa => aa.Title == "Book 1");
            return Ok(book);
        }

        [HttpGet("GetAllBooks")]
        public IActionResult GetAllBooks()
        {
            var books = _booksRepo.GetAll();
            return Ok(books);
        }

        [HttpGet("GetAllBooksWithAuthors")]
        public IActionResult GetAllBooksWithAuthors()
        {
            var book = _booksRepo.Find(a => a.Title.Contains("Book"), new[] { "Author" });
            return Ok(book);
        }

        [HttpGet("GetOrderd")]
        public IActionResult GetOrderd()
        {
            var books = _booksRepo.Find(a => a.Title.Contains("Book"), null, null, a => a.Id, OrderBy.Descending);
            return Ok(books);
        }

        [HttpPost("AddOne")]
        public IActionResult AddOne()
        {
            var book = _booksRepo.Add(new Book { Title = "Book 3", AuthorId = 1 });
            return Ok(book);
        }


    }
}
