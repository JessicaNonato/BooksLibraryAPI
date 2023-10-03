using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BooksLibraryAPI.Domain.Entities;

namespace BooksLibraryAPI.Service.Interfaces
{
    public interface IOrderService
    {
        public Task SaveOrderAsync(OrderEntity order);
    }
}
