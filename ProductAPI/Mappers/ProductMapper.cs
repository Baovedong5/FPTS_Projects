using ProductAPI.Core.Models;
using ProductAPI.Dtos;

namespace ProductAPI.Mappers
{
    public static class ProductMapper
    {
        public static ProductDto ToProductDto (this Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                AvailableQuantity = product.AvailableQuantity,
            };
        }

        public static Product ToProductFromCreateDto (this CreateProductDto createProductDto)
        {
            return new Product
            {
                Id = createProductDto.Id,
                Name = createProductDto.Name,
                Price = createProductDto.Price,
                AvailableQuantity = createProductDto.AvailableQuantity,
            };
        }

        public static Product ToProductFromUpdateDto (this UpdateProductDto updateProductDto)
        {
            return new Product
            {
                Name = updateProductDto.Name,
                Price = updateProductDto.Price,
                AvailableQuantity = updateProductDto.AvailableQuantity,
            };
        }
    }
}
