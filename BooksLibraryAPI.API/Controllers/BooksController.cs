using System;
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
        public IActionResult Get([FromRoute] int bookId)
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

        //[HttpGet]
        //public JsonResult GetAll()
        //{

        //    return Ok();
        //}

        [HttpPost]
        public IActionResult CreateBook(BookEntity book)
        {
               _bookService.CreateBookAsync(book);
               return Ok();

        }
    }
}
