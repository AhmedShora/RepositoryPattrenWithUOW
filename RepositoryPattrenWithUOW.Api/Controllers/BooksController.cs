using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPattrenWithUOW.Core;
using RepositoryPattrenWithUOW.Core.Consts;
using RepositoryPattrenWithUOW.Core.Models;

namespace RepositoryPattrenWithUOW.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public BooksController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetById()
        {
            var book = _unitOfWork.Books.GetById(1);
            return Ok(book);
        }

        [HttpGet("FindByName")]
        public IActionResult FindByName()
        {
            var book = _unitOfWork.Books.FilterBy(aa => aa.Title == "Book 1");
            return Ok(book);
        }

        [HttpGet("GetAllBooks")]
        public IActionResult GetAllBooks()
        {
            var books = _unitOfWork.Books.GetAll();
            return Ok(books);
        }

        [HttpGet("GetAllBooksWithAuthors")]
        public IActionResult GetAllBooksWithAuthors()
        {
            var book = _unitOfWork.Books.Find(a => a.Title.Contains("Book"), new[] { "Author" });
            return Ok(book);
        }

        [HttpGet("GetOrderd")]
        public IActionResult GetOrderd()
        {
            var books = _unitOfWork.Books.Find(a => a.Title.Contains("Book"), null, null, a => a.Id, OrderBy.Descending);
            return Ok(books);
        }

        [HttpPost("AddOne")]
        public IActionResult AddOne()
        {
            var book = _unitOfWork.Books.Add(new Book { Title = "Book 4", AuthorId = 1 });
            _unitOfWork.Complete();
            return Ok(book);
        }

        [HttpPost("AddRange")]
        public IActionResult AddRange()
        {
            var books = _unitOfWork.Books.AddRange(new Book[]
            {
                new Book { Title = "Book 3", AuthorId = 1 },
                new Book { Title = "Book 4", AuthorId = 1}
            });
            _unitOfWork.Complete();

            //var books_test = _unitOfWork.Books.GetSpecialBooks();
            return Ok(books);
        }


    }
}
