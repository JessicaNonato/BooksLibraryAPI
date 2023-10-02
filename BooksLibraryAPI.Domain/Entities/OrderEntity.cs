using System.Collections.Generic;
using BooksLibraryAPI.Domain.Models;

namespace BooksLibraryAPI.Domain.Entities
{
    public class OrderEntity
    {
        public List<BookEntity> Books { get; set; }

        public double Total { get; set; }
    }
}
