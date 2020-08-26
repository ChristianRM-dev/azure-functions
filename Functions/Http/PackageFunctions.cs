using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Api.Data;
using System.Collections.Generic;
using Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Api.Functions.Http
{
    public class PackageFunctions
    {
        static private DataContext _db;
        public PackageFunctions(DataContext context)
        {
            _db = context;
        }
        [FunctionName("GetPackages")]
        public async Task<IActionResult> GetPackages(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "packages")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Getting Packages");

            List<Package> packages = await _db
                .Packages
                .Select(p=> new Package
                {
                    Name = p.Name,
                    Price = p.Price,
                    PackageProducts = p.PackageProducts.Select(pp=> new PackageProduct
                    {
                        Product = pp.Product
                    }).ToList()
                })
                .ToListAsync();

            return new OkObjectResult(packages);
        }
    }
}
