using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Models
{
    public class OrderPackage
    {
        public int PackageId { get; set; }
        public virtual Package Package { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}
