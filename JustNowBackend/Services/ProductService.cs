using AutoMapper;
using JustNowBackend.Data;
using JustNowBackend.Data.Models;
using JustNowBackend.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JustNowBackend.Services
{
    public class ProductService : IProductService
    {
        private readonly MyDBContext dBContext;
        public ProductService(MyDBContext dBContext, IMapper mapper)
        {
            this.dBContext = dBContext;
        }
        public async Task AddProduct(Product product)
        {
            await dBContext.Products.AddAsync(product);
            await dBContext.SaveChangesAsync(); 
        }

        public async Task<Product?> DeleteProduct(int id)
        {
            var prod = dBContext.Products.FirstOrDefault(p => p.Id == id);
            if (prod != null) { dBContext.Products.Remove(prod); await dBContext.SaveChangesAsync(); }
            return prod;
        }

        public async Task<List<Product>> GetAllProductsOfRestaurant(int id)
        {
            
            return await dBContext.Products.Where(p => p.RestaurantId == id).ToListAsync();
        }


        public async Task<Product?> GetProductById(int id)
        {
            var obj =dBContext.Products.FirstOrDefault(x => x.Id == id);
            return obj;
        }

        public async Task<Product?> UpdateProduct(int id, Product product)
        {
            var prod = await dBContext.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (prod != null)
            {
                prod.Name = product.Name;
                prod.Price = product.Price;
                prod.PhotoUrl = product.PhotoUrl;
                prod.Description = product.Description;
            }
            await dBContext.SaveChangesAsync();
            return prod;
        }
    }
    
}
