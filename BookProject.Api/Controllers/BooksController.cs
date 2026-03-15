using BookProject.Api.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookProject.Api.Controllers
{
    //       api/books
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BooksController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var response = _context.Books.ToList();
            return Ok(response);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var response = _context.Books.Find(id);
            if (response is null) return NotFound();
            return Ok(response);
        }
        [HttpPost]
        public IActionResult Create(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();

            return Ok("Book is added successfully");
        }
        [HttpPut]
        public IActionResult Update(Book book)
        {
            var findBook = _context.Books.Find(book.Id);
            if (findBook is null) return NotFound();

            findBook.Title = book.Title;
            findBook.Author = book.Author;
            findBook.Price = book.Price;
            _context.SaveChanges();

            return Ok("Book is updated successfully");
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = _context.Books.Find(id);
            if (book is null) return NotFound();
            _context.Books.Remove(book);
            _context.SaveChanges();

            return Ok("Book is deleted successfully");
        }
    }
}
