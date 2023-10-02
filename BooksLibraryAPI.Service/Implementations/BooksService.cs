using System;
using System.Threading.Tasks;
using BooksLibraryAPI.Infra.Interfaces;
using BooksLibraryAPI.Service.Interfaces;
using BooksLibraryAPI.Domain.Entities;

namespace BooksLibraryAPI.Service.Implementations
{
    public class BooksService : IBooksService
    {
        private readonly IGenericRepository _genericRepository;

        public BooksService( IGenericRepository genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public object GetBookById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task CreateBookAsync(BookEntity book)
        {
            try
            {
                await _genericRepository.SaveAsync<BookEntity>(book, "book|", "BookStore");
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        //private BookEntity GetBookInfo(OrderEntity order)
        //{
        //    order.Books.ForEach(book =>
        //        {
        //            var bookInfo = _genericRepository.GetDocumentById<BookEntity>($"book/{book.bookId}");
        //        }
        //    );
        //}
    }
}
