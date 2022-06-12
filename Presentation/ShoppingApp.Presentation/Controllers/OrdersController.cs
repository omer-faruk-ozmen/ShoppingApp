using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Application.Repositories.Order;
using ShoppingApp.Domain.Entities;

namespace ShoppingApp.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderWriteRepository _orderWriteRepository;
        private readonly IOrderReadRepository _orderReadRepository;

        public OrdersController(IOrderWriteRepository orderWriteRepository, IOrderReadRepository orderReadRepository)
        {
            _orderWriteRepository = orderWriteRepository;
            _orderReadRepository = orderReadRepository;
        }

        [HttpPost]
        public async Task Add()
        {
            var guid = "7aa6e9bc-5209-4b82-83ee-0abd3cd454f5";


            await _orderWriteRepository.AddAsync(new()
            {
                Description = "Bla bla bla",
                Address = "Kars, Merkez",
                CustomerId = Guid.Parse(guid)
                
            });
            //await _orderWriteRepository.AddAsync(new()
            //{
            //    Description = "Bla bla bla 2",
            //    Address = "Kars"
            //});
            await _orderWriteRepository.SaveAsync();

        }
        [HttpGet]
        public async  Task<IActionResult> Get()
        {

           var order = _orderReadRepository.GetAll();

            return Ok(order);

        }
    }
}
