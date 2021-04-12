using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.Api.Entities;

namespace Catalog.Api.Services
{
    public interface ICatalogServices
    {
        Task<IEnumerable<Product>> GetCatalogProducts();
        Task<Product> GetCatalogProduct(string id);
        Task<IEnumerable<Product>> GetCatalogProductByName(string name);
        Task<IEnumerable<Product>> GetCatalogProductByCategory(string category);
        Task<Product> CreateCatalogProduct(Product product);
        Task<bool> UpdateCatalogProduct(Product product);
        Task<bool> DeleteCatalogProduct(string id);
    }
}