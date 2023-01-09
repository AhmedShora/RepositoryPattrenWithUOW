using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPattrenWithUOW.Core.Interfaces;
using RepositoryPattrenWithUOW.Core.Models;

namespace RepositoryPattrenWithUOW.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IBaseRepository<Author> _authorsRepo;

        public AuthorsController(IBaseRepository<Author> authorsRepo)
        {
            _authorsRepo = authorsRepo;
        }
        [HttpGet]
        public IActionResult GetById()
        {
            var author = _authorsRepo.GetById(1);
            return Ok(author);
        }

        [HttpGet("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync()
        {
            var author = await _authorsRepo.GetByIdAsync(1);
            return Ok(author);
        }


    }
}
