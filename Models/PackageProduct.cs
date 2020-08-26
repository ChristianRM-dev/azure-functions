using Newtonsoft.Json;

namespace Api.Models
{
    public class PackageProduct
    {
        public int PackageId { get; set; }
        public virtual Package Package { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
