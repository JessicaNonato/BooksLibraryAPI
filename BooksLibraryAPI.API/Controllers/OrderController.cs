using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksLibraryAPI.Domain.Entities;
using BooksLibraryAPI.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace BooksLibraryAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpPost]
        public IActionResult CreateOrder(OrderEntity order)
        {
            _orderService.SaveOrderAsync(order);
            return Ok();
        }
    }
}
