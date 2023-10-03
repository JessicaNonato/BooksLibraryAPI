using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BooksLibraryAPI.Domain.Entities;
using BooksLibraryAPI.Infra.Interfaces;
using BooksLibraryAPI.Service.Interfaces;

namespace BooksLibraryAPI.Service.Implementations
{
    public class OrderService: IOrderService
    {
        private readonly IGenericRepository _genericRepository;

        public OrderService(IGenericRepository genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task SaveOrderAsync(OrderEntity order)
        {
            try
            {
                order = GetBooksPrice(order);
                order.Total = CalculateOrderPrice(order);

                await _genericRepository.SaveAsync<OrderEntity>(order, "order|", "OrderBookStore");
            }
            catch (Exception)
            {
                throw;
            }

        }

        private OrderEntity GetBooksPrice(OrderEntity order)
        {
            order.Books.ForEach(book =>
                {
                    var bookInfo = _genericRepository.GetDocumentById<BookEntity>($"book/{book.bookId}");
                    book.price = bookInfo.price;
                }
            );
            return order;
        }

        private double CalculateOrderPrice(OrderEntity order)
        {
            var priceList = new List<double>();
            order.Books.ForEach(book =>
            {
                priceList.Add(book.price * book.quantity);
            });

            return priceList.Sum();

        }
    }
}
