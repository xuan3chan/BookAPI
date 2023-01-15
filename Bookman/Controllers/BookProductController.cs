using Bookman.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bookman.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookProductController : ControllerBase
    {
        private readonly IBook _bookRepo;

        public BookProductController(IBook repo)
        {
            _bookRepo = repo;
        }
        [HttpGet]
        public async Task<IActionResult>GetAllBooks()
        {
            try
            {
                return Ok(await _bookRepo.GetAllBooksAsyns());
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult>GetBookById(int Id)
        {
            var book = await _bookRepo.GetBookAsyns(Id);
            return book==null ? NotFound() : Ok(book);
        }

    }
}
