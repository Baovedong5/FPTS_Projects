using Customer_OrderAPI.Core.IRepositories;
using Customer_OrderAPI.DTOs.Customers;
using Customer_OrderAPI.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Customer_OrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetListCustomer()
        {
            var customers = await _customerRepository.ListAsync();

            var customerDto = customers?.Select(c => c.ToCustomerDto()) ?? Array.Empty<CustomerDto>();

            return Ok(customerDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);

            return Ok(customer.ToCustomerDto());
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerDto customerDto)
        {
            var customerModel = customerDto.ToCustomerFromCreateDto();

            await _customerRepository.CreateAsync(customerModel);

            return CreatedAtAction(nameof(GetById), new { id = customerModel.Id }, customerModel.ToCustomerDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer([FromRoute] int id,[FromBody] UpdateCustomerDto customerDto)
        {
            var customerModel = await _customerRepository.UpdateAsync(id, customerDto.ToCustomerFromUpdateDto());

            return Ok(customerModel.ToCustomerDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer([FromRoute] int id)
        {
            var customer = await _customerRepository.DeleteAsnc(id);

            return NoContent();
        }
    }
}
