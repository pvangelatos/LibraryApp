using FluentValidation;
using LibraryApp.Application.DTOs.Book;
using LibraryApp.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IValidator<BookCreateDto> _validator;

        public BooksController(IBookService bookService, IValidator<BookCreateDto> validator)
        {
            _bookService = bookService;
            _validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookService.GetAllAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var book = await _bookService.GetByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] BookCreateDto bookCreateDto)
        {
            var validation = await _validator.ValidateAsync(bookCreateDto);
            if (!validation.IsValid)
                return BadRequest(validation.Errors);

            var createdBook = await _bookService.CreateAsync(bookCreateDto);
            return CreatedAtAction(nameof(GetBookById), new { id = createdBook.Id }, createdBook);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] BookCreateDto bookCreateDto)
        {
            var validation = await _validator.ValidateAsync(bookCreateDto);
            if (!validation.IsValid)
                return BadRequest(validation.Errors);

            var updatedBook = await _bookService.UpdateAsync(id, bookCreateDto);
            return Ok(updatedBook);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var result = await _bookService.DeleteAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
