using Customer_OrderAPI.Core.Models;
using Customer_OrderAPI.DTOs.Customers;
using Customer_OrderAPI.DTOs.Orders;

namespace Customer_OrderAPI.Mappers
{
    public static class CustomerMapper
    {
        public static CustomerDto ToCustomerDto (this Customer customer)
        {
            return new CustomerDto
            {
                Id = customer.Id,
                Name = customer.Name,
                PhoneNumber = customer.PhoneNumber,
                Orders = customer.Orders?.Select(o => o.ToOrderDto()).ToList() ?? new List<OrderDto>(),
            };
        }

        public static Customer ToCustomerFromCreateDto (this CreateCustomerDto createCustomerDto)
        {
            return new Customer
            {
                Id = createCustomerDto.Id,
                Name = createCustomerDto.Name,
                PhoneNumber = createCustomerDto.PhoneNumber,
            };
        }

        public static Customer ToCustomerFromUpdateDto(this UpdateCustomerDto updateCustomerDto)
        {
            return new Customer
            {
                Name = updateCustomerDto.Name,
                PhoneNumber = updateCustomerDto.PhoneNumber,
            };
        }
    }
}

