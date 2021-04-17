using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.Api.Entities;
using Catalog.Api.Repositories;

namespace Catalog.Api.Services
{
    public class CatalogServices : ICatalogServices
    {
        private readonly IProductRepository _productRepository;
        
        public CatalogServices(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        
        public async Task<IEnumerable<Product>> GetCatalogProducts()
        {
            try
            {
                var products = await _productRepository.GetProducts();
                
                return products;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }

        public async Task<Product> GetCatalogProductById(string id)
        {
            try
            {
                var product = await _productRepository.GetProduct(id);

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
                var product = await _productRepository.GetProductByName(name);

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
                var product = await _productRepository.GetProductByCategory(category);

                return product;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }

        public async Task CreateCatalogProduct(Product data)
        {
            try
            {
                await _productRepository.CreateProduct(data);
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }

        public async Task<bool> UpdateCatalogProduct(string id, Product product)
        {
            try
            {
                await _productRepository.UpdateProduct(id, product);

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
                await _productRepository.DeleteProduct(id);

                return true;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }
    }
}