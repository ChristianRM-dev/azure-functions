using Newtonsoft.Json;

namespace Api.Models
{
    public class OrderDish
    {
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
