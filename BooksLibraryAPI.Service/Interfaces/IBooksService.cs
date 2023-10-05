using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BooksLibraryAPI.Domain.Entities;


namespace BooksLibraryAPI.Service.Interfaces
{
    public interface IBooksService
    {
        BookEntity GetBookById(string id);

        Task CreateBookAsync(BookEntity book);

        Task<List<BookEntity>> GetAllBooks<BookEntity>();

        Task DeleteBook<BookEntity>(string id);
    }
}
