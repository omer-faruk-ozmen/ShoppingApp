using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Application.Repositories.Customer;

namespace ShoppingApp.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerWriteRepository _customerWriteRepository;


        public CustomersController(ICustomerWriteRepository customerWriteRepository)
        {
            _customerWriteRepository = customerWriteRepository;
        }

        [HttpPost]
        public async Task Add()
        {
            await _customerWriteRepository.AddAsync(new()
            {
                Name = "Omer Faruk",

            });
            await _customerWriteRepository.SaveAsync();

        }
    }
}
