using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        public virtual ICollection<OrderDish> OrderProducts { get; set; }
        public virtual ICollection<PackageProduct> PackageProducts { get; set; }
    }
}
