using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        public BookEntity GetBookById(string id)
        {
            try
            {
             return _genericRepository.GetDocumentById<BookEntity>($"book/{id}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
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

        public Task<List<BookEntity>> GetAllBooks<BookEntity>()
        {
            try
            {
                return _genericRepository.GetAllDocuments<BookEntity>();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Task DeleteBook<BookEntity>(string id)
        {
            try
            {
                return _genericRepository.DeleteAsync<BookEntity>($"book/{id}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

    }
}
