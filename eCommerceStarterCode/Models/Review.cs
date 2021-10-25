using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceStarterCode.Models
{
    public class Review
    {
        public int Rating { get; set; }
        public string Content { get; set; }

        [ForeignKey("Products")]
        public int ProductId { get; set; }
        public Products Products { get; set; }
    }
}
