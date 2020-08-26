using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Api.Models;
using Api.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Api.Functions.Http
{
    public  class OrderFunctions
    {
        static private DataContext _db;
        public OrderFunctions(DataContext context)
        {
            _db = context;
        }
        [FunctionName("GetOrders")]
        public async Task<IActionResult> GetOrders(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "orders")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Getting Orders");
            List<Order> orders = await _db
                .Orders
                .ToListAsync();

            return new OkObjectResult(orders);
        }

        [FunctionName("GetOrder")]
        public async Task<IActionResult> GetOrder(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "order/{OrderId}")] HttpRequest req,
            ILogger log,int OrderId)
        {
            log.LogInformation("Getting Order:");
            Order order = await _db
                .Orders
                .Where(x => x.OrderId == OrderId)
                .FirstOrDefaultAsync();

            return new OkObjectResult(order);
        }
    }
}
