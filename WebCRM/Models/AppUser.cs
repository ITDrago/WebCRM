using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using System.ComponentModel.DataAnnotations;

namespace WebCRM.Models
{
    public class AppUser : IdentityUser
    {

        public ICollection<Customer> Customers { get; set; }

        public ICollection<Seller> Sellers { get; set; }

    }
}
