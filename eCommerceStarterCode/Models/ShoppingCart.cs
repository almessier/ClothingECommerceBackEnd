using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceStarterCode.Models
{
    public class ShoppingCart
    {
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("Products")]
        public int ProductId { get; set; }
        public Products Products { get; set; }

        public int Quantity { get; set; }
    }
}
