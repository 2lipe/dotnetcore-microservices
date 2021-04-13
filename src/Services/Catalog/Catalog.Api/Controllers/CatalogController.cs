using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Catalog.Api.Entities;
using Catalog.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Catalog.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CatalogController : ControllerBase
    {
        private readonly ICatalogServices _catalogServices;
        private readonly ILogger<CatalogController> _logger;
        
        public CatalogController(ICatalogServices catalogServices, ILogger<CatalogController> logger)
        {
            _catalogServices = catalogServices ?? throw new ArgumentNullException(nameof(catalogServices));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _catalogServices.GetCatalogProducts();

            return Ok(products);
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int) HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Product), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<Product>> GetProductById(string id)
        {
            var product = await _catalogServices.GetCatalogProductById(id);

            if (product == null)
            {
                _logger.LogError($"Product with id: {id}, not found.");
                return NotFound();
            }

            return Ok(product);
        }
    }
}