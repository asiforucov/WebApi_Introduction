using Library.DAL;
using Library.DTOs.Book;
using Library.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private AppDbContext _context { get; }
        public BookController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var book = _context.Books.FirstOrDefault(n => n.Id == id);
            if (book == null) return StatusCode(404);
            return Ok(book);
        }

        [HttpGet("")]
        public IActionResult GetAll()
        {
            var books = _context.Books.ToList();
            if (books is null) return StatusCode(404);
            return Ok(books);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBookDto bookDto)
        {
            if (bookDto == null) return StatusCode(404);
            var book = new Book()
            {
                Name = bookDto.Name,
                Price = bookDto.Price
            };

            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        
    }
}
