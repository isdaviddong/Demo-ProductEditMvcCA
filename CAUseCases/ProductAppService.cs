using Microsoft.EntityFrameworkCore;
using MvcProductCA.Entities;
using MvcProductCA.Infrastructure;

namespace MvcProductCA.UseCases
{
    // Application/Interfaces/Services/IProductAppService.cs
    public interface IProductAppService
    {
        ProductDTO GetProductById(int id);
        IEnumerable<ProductDTO> GetAllProducts();
        void CreateProduct(ProductDTO product);
        void UpdateProduct(ProductDTO product);
        void DeleteProduct(int id);
    }

    // Application/DTOs/ProductDTO.cs
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    // Application/Services/ProductAppService.cs
    public class ProductAppService : IProductAppService
    {
        private readonly IProductService _productService;

        public ProductAppService(IProductService productService)
        {
            _productService = productService;
        }

        public ProductDTO GetProductById(int id)
        {
            var product = _productService.GetById(id);
            return MapToDTO(product);
        }

        public IEnumerable<ProductDTO> GetAllProducts()
        {
            var products = _productService.GetAll();
            return products.Select(MapToDTO);
        }

        public void CreateProduct(ProductDTO product)
        {
            var newProduct = new Product()
            {
                Name = product.Name,
                Price = product.Price, 
            };

            _productService.Create(newProduct);
        }

        public void UpdateProduct(ProductDTO product)
        {
            var existingProduct = _productService.GetById(product.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
                _productService.Update(existingProduct);
            }
        }

        public void DeleteProduct(int id)
        {
            _productService.Delete(id);
        }

        private ProductDTO MapToDTO(Product product)
        {
            return new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };
        }
    }

}
