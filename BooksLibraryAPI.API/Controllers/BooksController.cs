using Microsoft.AspNetCore.Mvc;
using BooksLibraryAPI.API.Models;
using BooksLibraryAPI.Application.Services;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;


namespace BooksLibraryAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IConfiguration _configuration; 
        private readonly BooksService _booksService;
        

        public BooksController(BooksService booksService, IConfiguration configuration)
        {
            _booksService = booksService;
            _configuration = configuration;
        }
        

        [HttpGet]
        public JsonResult Get()
        {
        MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("BooksAPI"));

        var dbList = dbClient.GetDatabase("Books").GetCollection<Book>("Books").AsQueryable();

        return new JsonResult(dbList);
        }

    }
}
