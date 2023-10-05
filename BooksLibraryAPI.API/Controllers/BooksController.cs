using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BooksLibraryAPI.Domain.Entities;
using BooksLibraryAPI.Service.Interfaces;

namespace BooksLibraryAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _bookService;

        public BooksController(IBooksService bookService)
        {
            _bookService = bookService;
        }
        
        [HttpGet("{bookId}")]
        public IActionResult Get([FromRoute] string bookId)
        {
            try
            {
                var book = _bookService.GetBookById(bookId);
                return Ok(book);
            }
            catch (Exception)
            {
                throw;
            }
           
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = _bookService.GetAllBooks<BookEntity>();
            return Ok(books);
        }

        [HttpPost]
        public IActionResult CreateBook(BookEntity book)
        {
               _bookService.CreateBookAsync(book);
               return Ok();

        }

        [HttpDelete("{bookId}")]
        public IActionResult DeleteBook([FromRoute] string bookId)
        {
            try
            {
                var book = _bookService.DeleteBook<BookEntity>(bookId);
                return Ok(book);
            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}
