using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public bool Status { get; set; }
        public virtual ICollection<OrderDish> OrderProducts { get; set; }
        public virtual ICollection<OrderPackage> OrderPackages { get; set; }
    }
}
