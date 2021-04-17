using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.Api.Entities;

namespace Catalog.Api.Services
{
    public interface ICatalogServices
    {
        Task<IEnumerable<Product>> GetCatalogProducts();
        Task<Product> GetCatalogProductById(string id);
        Task<IEnumerable<Product>> GetCatalogProductByName(string name);
        Task<IEnumerable<Product>> GetCatalogProductByCategory(string category);
        Task CreateCatalogProduct(Product product);
        Task<bool> UpdateCatalogProduct(string id, Product product);
        Task<bool> DeleteCatalogProduct(string id);
    }
}