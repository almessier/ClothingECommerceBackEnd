using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace eCommerceStarterCode.Models
{
    public class User : IdentityUser
    {
        //public User()
        //{
        //    this.Products = new HashSet<Product>();
        //}
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //public virtual ICollection<Product> Products { get; set; }
    }
}
