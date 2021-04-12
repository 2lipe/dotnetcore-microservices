using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.Api.Entities;

namespace Catalog.Api.Services
{
    public class CatalogServices : ICatalogServices
    {
        private readonly ICatalogServices _catalogServices;
        
        public CatalogServices(ICatalogServices catalogServices)
        {
            _catalogServices = catalogServices;
        }
        
        public async Task<IEnumerable<Product>> GetCatalogProducts()
        {
            try
            {
                var products = await _catalogServices.GetCatalogProducts();
                
                return products;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }

        public async Task<Product> GetCatalogProduct(string id)
        {
            try
            {
                var product = await _catalogServices.GetCatalogProduct(id);

                return product;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }

        public async Task<IEnumerable<Product>> GetCatalogProductByName(string name)
        {
            try
            {
                var product = await _catalogServices.GetCatalogProductByName(name);

                return product;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }

        public async Task<IEnumerable<Product>> GetCatalogProductByCategory(string category)
        {
            try
            {
                var product = await _catalogServices.GetCatalogProductByCategory(category);

                return product;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }

        public async Task<Product> CreateCatalogProduct(Product data)
        {
            try
            {
                var product = await _catalogServices.CreateCatalogProduct(data);

                return product;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }

        public async Task<bool> UpdateCatalogProduct(Product product)
        {
            try
            {
                await _catalogServices.UpdateCatalogProduct(product);

                return true;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }

        public async Task<bool> DeleteCatalogProduct(string id)
        {
            try
            {
                await _catalogServices.DeleteCatalogProduct(id);

                return true;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }
    }
}