using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPattrenWithUOW.Core;
using RepositoryPattrenWithUOW.Core.Models;

namespace RepositoryPattrenWithUOW.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthorsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult GetById()
        {
            var author = _unitOfWork.Authors.GetById(1);
            return Ok(author);
        }

        [HttpGet("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync()
        {
            var author = await _unitOfWork.Authors.GetByIdAsync(1);
            return Ok(author);
        }


    }
}
