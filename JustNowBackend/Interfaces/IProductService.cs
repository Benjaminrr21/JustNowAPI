using JustNowBackend.Data.Models;

namespace JustNowBackend.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProductsOfRestaurant(int id);
        Task AddProduct(Product product);
        Task<Product> DeleteProduct(int id);
        Task<Product> GetProductById(int id);
        Task <Product?> UpdateProduct(int id, Product product);

    }
}
