using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Linq;
using Api.Data;
using System.Threading.Tasks;
using Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;

namespace Api.Functions.Http
{
    public class ProductFunctions
    {
        static private DataContext _db;
        public ProductFunctions(DataContext context)
        {
            _db = context;
        }

        [FunctionName("GetProducts")]
        public async Task<IActionResult> GetProducts(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "products")] HttpRequest req, ILogger log)
        {
            log.LogInformation("Gettign Products");
            List<Product> products = await _db.Products
                .OrderBy(p => p.ProductId)
                .ToListAsync();
                
            return new OkObjectResult(products);
        }

        [FunctionName("GetProduct")]
        public async Task<IActionResult> GetProduct(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "product/{ProductId}")] HttpRequest req, ILogger log, int ProductId)
        {
            log.LogInformation("Gettign Product:"+ ProductId);
            Product product = await _db.Products
                .Where(x => x.ProductId == ProductId)
                .FirstOrDefaultAsync();

            return new OkObjectResult(product);
        }

        [FunctionName("CreateProduct")]
        public async Task<IActionResult> CreateProduct(
             [HttpTrigger(AuthorizationLevel.Function, "post", Route = "product")] HttpRequest req, ILogger log, CancellationToken cts)
        {
            log.LogInformation("Creating Product");
            await _db.Products
                .AddAsync(new Product
                {
                    Name = "New Product",
                    Price = 35
                },cts);
            await _db.SaveChangesAsync(cts);
            return new OkObjectResult("Product Created");
        }
    }
}
