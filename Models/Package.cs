using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Api.Models
{
    public class Package
    {
        [Key]
        public int PackageId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public bool Available { get; set; }
        public decimal Price { get; set; }
        public virtual ICollection<PackageProduct> PackageProducts { get; set; }
        public virtual ICollection<OrderPackage> OrderPackages { get; set; }
    }
}
