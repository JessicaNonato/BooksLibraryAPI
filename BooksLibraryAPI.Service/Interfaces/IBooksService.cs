using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BooksLibraryAPI.Domain.Entities;


namespace BooksLibraryAPI.Service.Interfaces
{
    public interface IBooksService
    {
        object GetBookById(int id); //change the return

        Task CreateBookAsync(BookEntity book);

        //BookEntity GetBookInfo(OrderEntity order);
    }
}
